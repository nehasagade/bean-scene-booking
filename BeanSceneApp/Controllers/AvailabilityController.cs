using BeanSceneApp.Data;
using BeanSceneApp.ViewModels;
using BeanSceneApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

namespace BeanSceneApp.Controllers
{
    [Authorize(Roles = "Manager")]
    public class AvailabilityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvailabilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Availability
        public async Task<IActionResult> Index()
        {
            return _context.Availability != null ?
                         View(await _context.Availability.Where(a => a.Date >= DateTime.Today).ToListAsync()) :
                         Problem("Entity set 'ApplicationDbContext.Availability'  is null.");
        }

        // GET: Today's bookings
        public async Task<IActionResult> TodaysList()
        {
            return _context.Availability != null ?
                View(await _context.Availability.Where(b => b.Date == DateTime.Today.Date).ToListAsync()) : Problem("Entity set 'ApplicationDbContext.Availability' is null");
        }

        // GET: Availability/Create
        public IActionResult Create()
        {
            var areas = _context.Area;
            var model = new AvailabilityViewModel()
            {
                SittingTypeList = _context.SittingType.ToList(),
                Timeslot = _context.Timeslot.ToList(),
                Status = AvailabilityViewModel.StatusEnum.Available,
                SelectedAreas = new List<SelectedArea>(),
                SelectedAreaIds = new List<char>()
            };

            foreach (var area in areas)
            {
                model.SelectedAreas = model.SelectedAreas.Append<SelectedArea>(new SelectedArea
                {
                    AreaId = area.AreaId,
                    Name = area.Name,
                    ImageURL = area.ImageURL,
                    Selected = false
                });
            }

            return View(model);
        }

        // POST: Availability/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AvailabilityViewModel availabilityVM, char[] selectedAreaIds)
        {
            var areas = _context.Area;
            availabilityVM.SelectedAreas = new List<SelectedArea>();
            foreach (var area in areas)
            {
                availabilityVM.SelectedAreas = availabilityVM.SelectedAreas.Append<SelectedArea>(new SelectedArea
                {
                    AreaId = area.AreaId,
                    Name = area.Name,
                    ImageURL = area.ImageURL,
                    Selected = false
                });
            }



            if (availabilityVM.Availability.StartTime > availabilityVM.EndTime || availabilityVM.Availability.Date > availabilityVM.EndDate || availabilityVM.Availability.Date < DateTime.Now.Date || availabilityVM.EndDate < DateTime.Now.Date)
            {
                ModelState.AddModelError("", "Error. Please check the date & times are in the future and that end dates/times are after start ones.");
                availabilityVM.SittingTypeList = _context.SittingType.ToList();
                availabilityVM.Timeslot = _context.Timeslot.ToList();
                
                return View(availabilityVM);
            }

            try
            {
                int numOfSlots = Convert.ToInt32((availabilityVM.EndTime - availabilityVM.Availability.StartTime).TotalHours);
                int numOfDays = Convert.ToInt32((availabilityVM.EndDate - availabilityVM.Availability.Date).TotalDays);

                DateTime currentAvailabilityDate = availabilityVM.Availability.Date;
                
                for (int h = 0; h <= numOfDays; h++)
                {                  
                    TimeSpan timeslotStart = availabilityVM.Availability.StartTime;
                    for (int i = 0; i < numOfSlots; i++)
                    {
                        if (AvailabilityExists(currentAvailabilityDate, timeslotStart))
                        {
                            ModelState.AddModelError("", "A sitting with this date and time already exists.");
                            availabilityVM.SittingTypeList = _context.SittingType.ToList();
                            availabilityVM.Timeslot = _context.Timeslot.ToList();
                            return View(availabilityVM);
                        }

                        //int areaCount = 0;
                        availabilityVM.SelectedAreaIds = new List<char>();

                        // Loop through selected areas
                        foreach (char areaId in selectedAreaIds)
                        {
                            // Store area ID
                            availabilityVM.SelectedAreaIds = availabilityVM.SelectedAreaIds.Append(areaId);

                            // Make table availability
                            MakeTablesAvailable(currentAvailabilityDate, timeslotStart, areaId);
                        }

                        // Get total tables in areas
                        int tableCount = await _context.Table.Where(t => selectedAreaIds.Contains(t.AreaId)).CountAsync();

                        int maxCap = tableCount * 4;

                        var Availability = new Availability
                        {
                            SittingType = availabilityVM.Availability.SittingType,
                            Date = currentAvailabilityDate,
                            StartTime = timeslotStart,
                            MaxTables = maxCap,
                            TablesAvailable = tableCount,
                            MaxCapacity = maxCap,
                            Capacity = maxCap,
                            Status = (Availability.StatusEnum)AvailabilityViewModel.StatusEnum.Available
                        };
                        _context.Add(Availability);
                        _context.SaveChanges();

                        timeslotStart += new TimeSpan(1, 0, 0);
                    }
                    currentAvailabilityDate = currentAvailabilityDate.AddDays(1);
                }                
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {                            
                ModelState.AddModelError("", "Something went wrong. Try again later.");
                availabilityVM.SittingTypeList = _context.SittingType.ToList();
                availabilityVM.Timeslot = _context.Timeslot.ToList();
                return View(availabilityVM);
            }                        
                    
        }

        // GET: Availability/Edit/{id}
        [Route("Availability/Edit/{Date}/{StartTime}")]
        public IActionResult Edit(DateTime? date, TimeSpan? startTime)
        {
            if (date == null || startTime == null || _context.Availability == null)
            {
                return NotFound();
            }

            var availability = _context.Availability
                .Find(date, startTime);

            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // POST: Availability/Edit/{id}
        [HttpPost, ValidateAntiForgeryToken]
        [Route("Availability/Edit/{Date}/{StartTime}")]
        public async Task<IActionResult> Edit(Availability availability)
        {
            _context.Update(availability);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Availability/Delete/{id}
        [Route("Availability/Delete/{Date}/{StartTime}")]
        public IActionResult Delete(DateTime? date, TimeSpan? startTime)
        {
            if (date == null || startTime == null || _context.Availability == null)
            {
                return NotFound();
            }

            var availability = _context.Availability.Find(date, startTime);

            if (availability == null)
            {
                return NotFound();
            }

            return View(availability);
        }

        // POST: Availability/Delete/{id}
        [Route("Availability/Delete/{Date}/{StartTime}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(DateTime date, TimeSpan startTime)
        {
            if (_context.Availability == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Availability' is null.");
            }

            var availability = await _context.Availability.FindAsync(date, startTime);
            if (availability != null)
            {
                _context.Availability.Remove(availability);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Close a timeslot for booking by users.
        public IActionResult Close(string? date, TimeSpan? time)
        {
            if (date != null && time != null)
            {
                DateTime bDate = DateTime.Parse(date);
                Availability availabilityToClose = _context.Availability.Find(bDate, time);

                if (availabilityToClose != null)
                {
                    availabilityToClose.Status = Availability.StatusEnum.Closed;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            return NotFound();
        }

        // Make Tables available for a given availability
        private void MakeTablesAvailable(DateTime date, TimeSpan timeslot, char areaId)
        {
            int numOfTables = _context.Table
                .Where(t => t.AreaId == areaId)
                .Count();
            for (int i = 0; i < numOfTables; i++)
            {
                var AvailableTable = new AvailableTable
                {
                    AreaId = areaId,
                    TableNum = i + 1,
                    Date = date,
                    StartTime = timeslot
                };
                    
                _context.Add(AvailableTable);
                //_context.SaveChangesAsync(); 
            }
            
        }

        private bool AvailabilityExists(DateTime date, TimeSpan time)
        {
            var availability = _context.Availability.Find(date, time);
            if (availability != null && availability.Status != Availability.StatusEnum.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
