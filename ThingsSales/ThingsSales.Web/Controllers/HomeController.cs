using Microsoft.AspNetCore.Mvc;
using ThingsSales.Service.IService;

namespace ThingsSales.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = HttpContext.Session.GetString("UserId");
            var user = await _userService.GetUserFullNameById(userId);

            if (user != null)
            {
                string fullName = $"{user.FirstName} {user.LastName}";
                return View(model: fullName);
            }

            return NotFound();
        }

    }
}
