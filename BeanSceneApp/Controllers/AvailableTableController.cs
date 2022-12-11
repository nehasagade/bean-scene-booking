using BeanSceneApp.Data;
using BeanSceneApp.Models;
using BeanSceneApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeanSceneApp.Controllers
{
    [Authorize(Roles = "Staff")]
    public class AvailableTableController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AvailableTableController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var AvailableTables = _context.AvailableTable
                .OrderBy(a => a.Date)
                .ToList();
            return View(AvailableTables);
        }

        // GET: Available Tables for a Requested booking date
        public IActionResult SearchTable(int id)
        {
            try
            {
                var booking = _context.Booking
                    .Include(b => b.AvailableTables)
                    .FirstOrDefault(b => b.Id == id);
                var AvailableTables = new List<AvailableTable>();

                AvailableTables = _context.AvailableTable
                    .Where(a => a.Date == booking.Date)
                    .Where(a => a.StartTime == booking.StartTime)
                    .Where(a => a.BookingId == null)
                    .OrderBy(a => a.Date)
                    .ToList();


                BookingAvailableTableViewModel model = new()
                {
                    Booking = booking,
                    AvailableTables = AvailableTables
                };

                return View(model);
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }

        public IActionResult AddToBooking(string date, TimeSpan time, char areaId, int tableNum, int bookingId)
        {
            DateTime bDate = DateTime.Parse(date);
            var availableTable = _context.AvailableTable.Find(bDate, time, areaId, tableNum);
            var booking = _context.Booking
                .Include(b => b.AvailableTables)
                .FirstOrDefault(b => b.Id == bookingId);

            if (availableTable == null || booking == null)
            {
                return NotFound();
            }

            try
            {
                availableTable.BookingId = bookingId;
                _context.Update(availableTable);
                _context.SaveChanges();

                if (booking.RequiredTables != booking.AvailableTables.Count())
                {
                    return RedirectToAction("SearchTable", new { id = bookingId });
                }


                var availability = _context.Availability
                    .Find(booking.Date, booking.StartTime);

                availability.Capacity -= booking.NumOfGuests;
                availability.TablesAvailable -= booking.RequiredTables;

                if (availability.Capacity == 0 || availability.TablesAvailable == 0)
                {
                    availability.Status = Availability.StatusEnum.Closed;
                }
                
                booking.Status = Booking.StatusEnum.Confirmed;

                _context.Update(booking);
                _context.SaveChanges();
                return RedirectToAction("Index", "Booking");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Sorry, something went wrong. Try again later.");
                return RedirectToAction("Index", "Booking", booking);
            }
        }

        public IActionResult SearchTablePrivate(int id)
        {
            var booking = _context.Booking.Find(id);

            if(booking == null)
            {
                return NotFound();
            }

            var AvailableTables = new List<AvailableTable>();
            // Get all the slots for this private event
            var allBookings = _context.Booking                        
                                    .Where(b => b.IsPrivateBooking)
                                    .Where(b => b.FirstName == booking.FirstName)
                                    .Where(b => b.LastName == booking.LastName)
                                    .Where(b => b.Email == booking.Email)
                                    .Where(b => b.Phone == booking.Phone)
                                    .Where(b => b.NumOfGuests == booking.NumOfGuests)
                                    .Where(b => b.RequiredTables == booking.RequiredTables)
                                    .Include(b => b.AvailableTables);
            // For each slot, get all the available tables, make them a list.
            foreach (var privateBooking in allBookings)
            {
                var tables = _context.AvailableTable
                                    .Where(a => a.Date == privateBooking.Date)
                                    .Where(a => a.StartTime == privateBooking.StartTime)
                                    .Where(a => a.BookingId == null)
                                    .ToList();
                AvailableTables.AddRange(tables);
            }
            
            PrivateBookingAvailableTable model = new PrivateBookingAvailableTable { Booking = allBookings, AvailableTables = AvailableTables };          
            return View(model);
        }

        public IActionResult AddToBookingPrivate(string date, TimeSpan time, char areaId, int tableNum, int bookingId)
        {
            // Find the booking and the table
            DateTime bDate = DateTime.Parse(date);
            var availableTable = _context.AvailableTable.Find(bDate, time, areaId, tableNum);
            var booking = _context.Booking
                .Include(b => b.AvailableTables)
                .FirstOrDefault(b => b.Id == bookingId);

            if (availableTable == null || booking == null)
            {
                return NotFound();
            }

            availableTable.BookingId = bookingId;
            _context.Update(availableTable);
            _context.SaveChanges();


            if (booking.AvailableTables.Count() < booking.RequiredTables)
            {
                return RedirectToAction("SearchTablePrivate", new { id = bookingId });
            }
            else
            {
                booking.Status = Booking.StatusEnum.Confirmed;
                _context.Update(booking);
                _context.SaveChanges();
            }

            var availability = _context.Availability
                .Find(booking.Date, booking.StartTime);

            availability.Capacity -= booking.NumOfGuests;
            availability.TablesAvailable -= booking.RequiredTables;
            
            if (availability.Capacity == 0 || availability.TablesAvailable == 0)
            {
                availability.Status = Availability.StatusEnum.Closed;
            }

            _context.Update(availability);
            _context.SaveChanges();

            var allBookings = _context.Booking.Where(b => b.IsPrivateBooking)
                                .Where(b => b.FirstName == booking.FirstName)
                                .Where(b => b.LastName == booking.LastName)
                                .Where(b => b.Email == booking.Email)
                                .Where(b => b.Phone == booking.Phone)
                                .Where(b => b.NumOfGuests == booking.NumOfGuests)
                                .Where(b => b.RequiredTables == booking.RequiredTables)
                                .Include(b => b.AvailableTables);

            // If not all slots in this private booking are confirmed, then go to search tables.
            bool statusConfirmed = true;

            foreach (var book in allBookings)
            {
                if (book.Status != Booking.StatusEnum.Confirmed)
                {
                    statusConfirmed = false;
                }
            }

            if (!statusConfirmed)
            {
                return RedirectToAction("SearchTablePrivate", new { id = bookingId });
            }

            return RedirectToAction("Index", "Booking");
        }
    }
}
