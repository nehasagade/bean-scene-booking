using BeanSceneApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeanSceneApp.ViewModels;
using BeanSceneApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BeanSceneApp.Controllers
{
    [Authorize(Roles = "Staff")]
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all the current bookings for the Index page.
        /// </summary>
        /// <returns>A list of all bookings for the view.</returns>
        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            return _context.Booking != null ?
                View(await _context.Booking
                    .Where(b => b.Date >= DateTime.Today.Date)
                    .Where(b => b.Status != Booking.StatusEnum.Cancelled && b.Status != Booking.StatusEnum.Completed)
                    .Include(b => b.AvailableTables)
                    .OrderBy(b => b.Date)
                    .ToListAsync()) 
                : Problem("Entity set 'ApplicationDbContext.Booking is null");
        }

        #region BookingStatusViews
        // GET: Today's bookings
        public async Task<IActionResult> TodaysList()
        {
            return _context.Booking != null ?
                View(await _context.Booking
                    .Where(b => b.Date == DateTime.Today.Date)
                    .OrderBy(b => b.Date)
                    .ToListAsync()) 
                : Problem("Entity set 'ApplicationDbContext.Booking is null");
        }

        // GET: Pending Bookings
        public async Task<IActionResult> PendingList()
        {
            return _context.Booking != null ? 
                View(await _context.Booking
                    .Where(b => b.Date >= DateTime.Today.Date)
                    .Where(b => b.Status == Booking.StatusEnum.Pending)
                    .OrderBy(b => b.Date)
                    .ToListAsync()) 
                : Problem("Entity set 'ApplicationDbCOntext.Booking' is null");
        }

        // GET: Confirmed Bookings
        public async Task<IActionResult> ConfirmedList()
        {
            return _context.Booking != null ?
                        View(await _context.Booking
                        .Where(b => b.Date >= DateTime.Today.Date)
                        .Where(b => b.Status == Booking.StatusEnum.Confirmed)
                        .OrderBy(b => b.Date)
                        .ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Booking'  is null.");
        }

        //GET: Cancelled bookings
        public async Task<IActionResult> CancelledList()
        {
            return _context.Booking != null ? 
                View(await _context.Booking
                    .Where(b => b.Date >= DateTime.Today.Date)
                    .Where(b => b.Status == Booking.StatusEnum.Cancelled)
                    .OrderBy(b => b.Date)
                    .ToListAsync()) 
                : Problem("Entity set 'ApplicationDbCOntext.Booking' is null");
        }

        //GET: Seated bookings
        public async Task<IActionResult> SeatedList()
        {
            return _context.Booking != null ? 
                View(await _context.Booking
                    .Where(b => b.Status == Booking.StatusEnum.Seated)
                    .OrderBy(b => b.Date)
                    .ToListAsync()) 
                : Problem("Entity set 'ApplicationDbCOntext.Booking' is null");
        }

        //GET: Completed bookings
        public async Task<IActionResult> CompletedList()
        {
            return _context.Booking != null ? 
                View(await _context.Booking
                    .Where(b => b.Date >= DateTime.Today.Date)
                    .Where(b => b.Status == Booking.StatusEnum.Completed)
                    .ToListAsync()) 
                : Problem("Entity set 'ApplicationDbCOntext.Booking' is null");
        }
        #endregion BookingStatus Views
        [AllowAnonymous]
        // GET: Booking/Create
        public IActionResult Create()
        {
            var model = new BookingViewModel()
            {
                Availability = _context.Availability.ToList(),
                Timeslots = _context.Timeslot.ToList()
            };

            if (User.IsInRole("Customer"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    model.UserId = user.Id;
                    model.FirstName = user.FirstName;
                    model.LastName = user.LastName;
                    model.Phone = user.PhoneNumber;
                    model.Email = user.Email;
                }
            }

            if (User.IsInRole("Customer") || User == null)
            {
                model.Source = BookingViewModel.SourceEnum.Online;
            }
            return View(model);
        }

        // POST: Booking/Create
        [AllowAnonymous]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingViewModel bookingVM)
        {
            bookingVM.Timeslots = _context.Timeslot.ToList();

            if (bookingVM == null)
            {
                return NotFound();
            }

            bool availabilityExists = AvailabilityExists(bookingVM.Date, bookingVM.StartTime, false);
            
            if (!availabilityExists)
            {
                ModelState.AddModelError("", "This date and time is not available to be booked. Please select another date or time.");
                return View(bookingVM);
            }

            if (bookingVM.Date < DateTime.Now.Date || bookingVM.NumOfGuests <= 0)
            {
                ModelState.AddModelError("", "Please ensure the date is today or in the future, and that the number of guests is greater than zero.");
                return View(bookingVM);
            }

            try
            {
                var Booking = new Booking
                {
                    UserId = bookingVM.UserId,
                    FirstName = bookingVM.FirstName,
                    LastName = bookingVM.LastName,
                    Email = bookingVM.Email,
                    Phone = bookingVM.Phone,
                    Date = bookingVM.Date,
                    StartTime = bookingVM.StartTime,
                    NumOfGuests = bookingVM.NumOfGuests,
                    RequiredTables = CalculateTables(bookingVM.NumOfGuests),
                    Note = bookingVM.Note,
                    Source = (Booking.SourceEnum)bookingVM.Source,
                    Status = (Booking.StatusEnum)bookingVM.Status
                };

                _context.Add(Booking);
                await _context.SaveChangesAsync();

                if (User.IsInRole("Customer"))
                {
                    return RedirectToAction("Index", "MemberBooking");
                }
                else if (User.IsInRole("Staff") || User.IsInRole("Manager"))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("BookingSent");
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Something went wrong. Please try again later.");
                return View(bookingVM);
            }
            
        }

        [AllowAnonymous]
        public IActionResult BookingSent()
        {
            return View();
        }

        // GET: Booking/PrivateBooking
        [AllowAnonymous]
        public IActionResult PrivateBooking()
        {
            var model = new PrivateBookingViewModel()
            {
                SittingTypeList = _context.SittingType.ToList(),
                Availability = _context.Availability.ToList(),
            };

            if (User.IsInRole("Customer"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                if (user != null)
                {
                    model.UserId = user.Id;
                    model.FirstName = user.FirstName;
                    model.LastName = user.LastName;
                    model.Phone = user.PhoneNumber;
                    model.Email = user.Email;
                }
            }
            return View(model);
        }

        // POST: Booking/PrivateBooking
        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> PrivateBooking(PrivateBookingViewModel privateVM)
        {
            privateVM.SittingTypeList = _context.SittingType.ToList();
            privateVM.Availability = _context.Availability.ToList();

            if (privateVM == null)
            {
                return NotFound();
            }

            if (privateVM.Date < DateTime.Now.Date || privateVM.NumOfGuests <= 0)
            {
                ModelState.AddModelError("", "Please ensure the date is date in the future, and that the number of guests is greater than zero.");
                return View(privateVM);
            }

            var availabilities = _context.Availability.ToList()
                                    .Where(a => a.Date == privateVM.Date)
                                    .Where(a => a.SittingType == privateVM.SittingType)
                                    .Where(a => a.Status != Availability.StatusEnum.Closed);

            if (availabilities == null)
            {
                ModelState.AddModelError("", "This date and time is not available to be booked. Please select another date or time.");
                return View(privateVM);
            }
            
            privateVM.StartTime = availabilities.ElementAt(0).StartTime;
            privateVM.RequiredTables = CalculateTables(privateVM.NumOfGuests);

            // Calculate if all timeslots in a sitting are available
            bool allSlotsAvailable = true;

            foreach (var availability in availabilities)
            {
                if (availability.Capacity < privateVM.NumOfGuests || availability.TablesAvailable < privateVM.RequiredTables)
                {
                    allSlotsAvailable = false;
                }

            }

            int numOfSlots = availabilities.Count();
            
            if (allSlotsAvailable)
            {
                for (int i = 0; i < numOfSlots; i++)
                {
                    var Booking = new Booking
                    {
                        UserId = privateVM.UserId,
                        FirstName = privateVM.FirstName,
                        LastName = privateVM.LastName,
                        Email = privateVM.Email,
                        Phone = privateVM.Phone,
                        Date = privateVM.Date,
                        StartTime = privateVM.StartTime,
                        NumOfGuests = privateVM.NumOfGuests,
                        RequiredTables = privateVM.RequiredTables,
                        Note = "PRIVATE EVENT " + privateVM.Note,
                        Source = (Booking.SourceEnum)privateVM.Source,
                        Status = (Booking.StatusEnum)privateVM.Status,
                        IsPrivateBooking = true
                    };

                    _context.Add(Booking);
                    privateVM.StartTime += new TimeSpan(1, 0, 0);
                }
            }
            else
            {
                ModelState.AddModelError("", "Sorry, the time requested is unavailable. Please try another date or sitting.");
                return View(privateVM);
            }
            
            await _context.SaveChangesAsync();

            if (User.IsInRole("Customer"))
            {
                return RedirectToAction("Index", "MemberBooking");
            }
            else if (User.IsInRole("Staff") || User.IsInRole("Manager"))
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Booking/Detail/{id}
        public IActionResult Detail(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var booking = _context.Booking.Find(id);
            return View(booking);
        }

        // GET: Booking/Edit/{id}
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var booking = _context.Booking.Find(id);
            return View(booking);
        }

        // POST: Booking/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Booking booking)
        {
            return RedirectToAction("Index");
        }
        #region StatusChanges

        // Checks booking can be made & changes status
        public IActionResult Confirm(int? id)
        {
            if (id != 0)
            {
                Booking bookingToConfirm = _context.Booking.Find(id);

                if (bookingToConfirm.IsPrivateBooking == true)
                {
                    var privateBookingsToConfirm = _context.Booking.ToList()
                        .Where(b => b.IsPrivateBooking == true)
                        .Where(b => b.Date == bookingToConfirm.Date)
                        .Where(b => b.FirstName == bookingToConfirm.FirstName)
                        .Where(b => b.LastName == bookingToConfirm.LastName)
                        .Where(b => b.Email == bookingToConfirm.Email)
                        .Where(b => b.Phone == bookingToConfirm.Phone)
                        .Where(b => b.NumOfGuests == bookingToConfirm.NumOfGuests)
                        .Where(b => b.RequiredTables == bookingToConfirm.RequiredTables);

                    foreach (var booking in privateBookingsToConfirm)
                    {
                        SubtractAvailability(booking);
                    }
                }
                else
                {
                    SubtractAvailability(bookingToConfirm);
                }
               
                _context.SaveChanges();
                return RedirectToAction("Index");
                
            }
            return View();
        }

        public IActionResult Cancel(int? id)
        {
            if (id != 0)
            {
                Booking bookingToCancel = _context.Booking.Find(id);

                if (bookingToCancel.IsPrivateBooking == true)
                {   
                    var privateBookingsToCancel = GetPrivateBookings(bookingToCancel);

                    foreach (var booking in privateBookingsToCancel)
                    {
                        // Make the tables available again
                        var availableTables = _context.AvailableTable.Where(a => a.BookingId == booking.Id);
                        foreach (var table in availableTables)
                        {
                            table.BookingId = null;
                        }

                        // Number of Guests and tables aren't taken off the Availability capacity until the booking is confirmed.
                        if (booking.Status == Booking.StatusEnum.Confirmed)
                        {
                            AddAvailability(booking);
                        }

                        booking.Status = Booking.StatusEnum.Cancelled;
                        _context.SaveChanges();
                    }
                }
                else
                {
                    var availableTables = _context.AvailableTable.Where(a => a.BookingId == bookingToCancel.Id);
                    foreach (var table in availableTables)
                    {
                        table.BookingId = null;
                    }

                    if (bookingToCancel.Status == Booking.StatusEnum.Confirmed)
                    {
                        AddAvailability(bookingToCancel);
                    }

                    bookingToCancel.Status = Booking.StatusEnum.Cancelled;
                }
                
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Seat(int? id)
        {
            if (id != 0)
            {
                Booking bookingToSeat = _context.Booking.Find(id);

                if (bookingToSeat.IsPrivateBooking == true)
                {
                    var privateBookingsToSeat = GetPrivateBookings(bookingToSeat);

                    foreach (var booking in privateBookingsToSeat)
                    {
                        booking.Status = Booking.StatusEnum.Seated;
                    }
                }
                else
                {
                    bookingToSeat.Status = Booking.StatusEnum.Seated;
                }
                
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Complete(int? id)
        {
            if (id != 0)
            {
                Booking bookingToComplete = _context.Booking.Find(id);

                if (bookingToComplete.IsPrivateBooking == true)
                {
                    var privateBookingsToComplete = GetPrivateBookings(bookingToComplete);

                    foreach (var booking in privateBookingsToComplete)
                    {
                        booking.Status = Booking.StatusEnum.Completed;
                    }
                }
                else
                {
                    bookingToComplete.Status = Booking.StatusEnum.Completed;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View();
        }

        #endregion StatusChanges

        // For when a booking is confirmed.
        private void SubtractAvailability(Booking bookingToConfirm)
        {
            // Change sitting capacity
            var availability = _context.Availability
                .Find(bookingToConfirm.Date, bookingToConfirm.StartTime);
            if (availability.Capacity > 0 || availability.TablesAvailable > 0)
            {
                availability.Capacity -= bookingToConfirm.NumOfGuests;
                availability.TablesAvailable -= bookingToConfirm.RequiredTables;
            }
            bookingToConfirm.Status = Booking.StatusEnum.Confirmed;
        }

        // For when a booking is cancelled.
        private void AddAvailability(Booking bookingToCancel)
        {
            // Change sitting capacity
            var availability = _context.Availability
                .Find(bookingToCancel.Date, bookingToCancel.StartTime);

            availability.Capacity += bookingToCancel.NumOfGuests;
            availability.TablesAvailable += bookingToCancel.RequiredTables;

            bookingToCancel.Status = Booking.StatusEnum.Cancelled;
        }

        private static int CalculateTables(int guests)
        {
            int requiredTables;
            if (guests % 4 == 0)
            {
                requiredTables = guests / 4;
            }
            else
            {
                requiredTables = (guests / 4) + 1;
            }
            return requiredTables;
        }

        private IEnumerable<Booking> GetPrivateBookings(Booking booking)
        {
            var privatebookings = _context.Booking
                        .Where(b => b.IsPrivateBooking == true)
                        .Where(b => b.Date == booking.Date)
                        .Where(b => b.FirstName == booking.FirstName)
                        .Where(b => b.LastName == booking.LastName)
                        .Where(b => b.Email == booking.Email)
                        .Where(b => b.Phone == booking.Phone)
                        .Where(b => b.NumOfGuests == booking.NumOfGuests)
                        .Where(b => b.RequiredTables == booking.RequiredTables)
                        .ToList();
            return privatebookings;
        }

        private bool AvailabilityExists(DateTime date, TimeSpan time, bool IsPrivate)
        {
            
            var availability = _context.Availability.Find(date, time);

            if (availability == null)
            {
                return false;
            }

            if (availability.SittingType == "Private Event" && !IsPrivate)
            {
                return false;
            }
            else if (availability.Status == Availability.StatusEnum.Closed || availability.Capacity == 0 || availability.TablesAvailable == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
