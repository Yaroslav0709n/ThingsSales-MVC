using Microsoft.AspNetCore.Mvc;
using ThingsSales.Service.IService;

namespace ThingsSales.Web.Controllers
{
    public class UserAdvertisementsController : Controller
    {
        private readonly IAdvertismentService _advertismentService;

        public UserAdvertisementsController(IAdvertismentService advertismentService)
        {
            _advertismentService = advertismentService;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetUserItems()
        {
            string userId = HttpContext.Session.GetString("UserId");

            var items = await _advertismentService.GetAllItems(userId);
            return View(items);
        }

    }
}
