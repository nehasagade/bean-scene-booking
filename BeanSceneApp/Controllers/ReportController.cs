using BeanSceneApp.Models;
using BeanSceneApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using Microsoft.AspNetCore.Authorization;

namespace BeanSceneApp.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ReportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookingReport()
        {
            return View();
        }
        public IActionResult PrivateBookingReport()
        {
            DateTime today = DateTime.Now.Date;
            DateTime oneMonth = today.AddDays(31);
            var bookings = _context.Booking
                .Where(b => b.Date > today)
                .Where(b => b.Date < oneMonth)
                .Where(b => b.IsPrivateBooking == true);

            return View(bookings);
                
        }
        public IActionResult BookingByDateReport()
        {
            DateTime today = DateTime.Now.Date;
            DateTime oneMonthAgo = today.AddDays(-31);
            var bookings = _context.Booking
                .Where(b => b.Date < today)
                .Where(b => b.Date > oneMonthAgo)
                .Where(b => b.Status == Booking.StatusEnum.Completed);

            // Store the Date and number of bookings in a dictionary
            Dictionary<DateTime, int> finalList = new();
            foreach (var booking in bookings)
            {
                if (finalList.ContainsKey(booking.Date))
                {
                    finalList[booking.Date]++;
                }
                else
                {
                    finalList.Add(booking.Date, 1);
                }
            }
            return View(finalList);
        }

        public IActionResult BookingByTimeReport()
        {
            DateTime today = DateTime.Now.Date;
            DateTime oneMonthAgo = today.AddDays(-31);
            var bookings = _context.Booking
                .Where(b => b.Date < today)
                .Where(b => b.Date > oneMonthAgo)
                .Where(b => b.Status == Booking.StatusEnum.Completed);
                

            // Store the Date and number of bookings in a dictionary
            Dictionary<TimeSpan, int> finalList = new();
            foreach (var booking in bookings)
            {
                if (finalList.ContainsKey(booking.StartTime))
                {
                    finalList[booking.StartTime]++;
                }
                else
                {
                    finalList.Add(booking.StartTime, 1);
                }
            }
            return View(finalList.OrderBy(f => f.Key));
        }

        public IActionResult GuestsByDateReport()
        {
            DateTime today = DateTime.Now.Date;
            DateTime oneMonthAgo = today.AddDays(-31);
            var bookings = _context.Booking
                .Where(b => b.Date < today)
                .Where(b => b.Date > oneMonthAgo)
                .Where(b => b.Status == Booking.StatusEnum.Completed);

            // Store the Date and number of bookings in a dictionary
            Dictionary<DateTime, int> finalList = new();
            foreach (var booking in bookings)
            {
                if (finalList.ContainsKey(booking.Date))
                {
                    finalList[booking.Date] += booking.NumOfGuests;
                }
                else
                {
                    finalList.Add(booking.Date, booking.NumOfGuests);
                }
            }
            return View(finalList);
        }
    }
}
