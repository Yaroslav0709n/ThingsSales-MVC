using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThingsSales.Data.Common;
using ThingsSales.Data.ContextData;

namespace ThingsSales.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            string userId = HttpContext.Session.GetString("UserId");
            var user = _context.ApplicationUsers.FirstOrDefault(u => u.Id == userId.ToString());

            if (user != null)
            {
                string fullName = $"{user.FirstName} {user.LastName}";
                return View(model: fullName);
            }

            return NotFound();
        }

    }
}
