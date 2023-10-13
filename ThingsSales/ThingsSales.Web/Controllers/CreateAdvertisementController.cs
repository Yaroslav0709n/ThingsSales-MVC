using Microsoft.AspNetCore.Mvc;
using ThingsSales.Service.IService;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Web.Controllers
{
    public class CreateAdvertisementController : Controller
    {
        private readonly IAdvertismentService _advertismentService;
        public CreateAdvertisementController(IAdvertismentService advertismentService)
        {
            _advertismentService = advertismentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> InsertItem(AdvertisementViewModel item, List<IFormFile> photos)
        {
            string userId = HttpContext.Session.GetString("UserId");

            await _advertismentService.InsertItem(item, photos, userId);

            return RedirectToAction("Index", "UserAdvertisements");
        }
    }
}
