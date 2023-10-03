using Microsoft.AspNetCore.Mvc;
using ThingsSales.Data.ValidationExtensions;
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

            var user = await _userService.GetUserById(userId);

            user.ThrowIfNull(nameof(user));

            return View(user);
        }

    }
}
