using Microsoft.AspNetCore.Mvc;
using ThingsSales.Data.ValidationExtensions;
using ThingsSales.Service.IService;
using ThingsSales.Service.Service;

namespace ThingsSales.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> Index()
        {
            string userId = HttpContext.Session.GetString("UserId");

            var user = await _userService.GetUserById(userId);

            user.ThrowIfNull(nameof(user));

            return View(user);
        }

    }
}
