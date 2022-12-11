using BeanSceneApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BeanSceneApp.Controllers
{
    [Authorize(Roles = "Customer")]
    public class MemberBookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MemberBookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Bookings for a particular user
        // GET: Booking/MyBookings
        public async Task<IActionResult> Index()
        {                   
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var usersBookings = await _context.Booking.Where(b => b.UserId == userId).ToListAsync();
                return View(usersBookings);
            }

            return View();
         
        }
    }
}
