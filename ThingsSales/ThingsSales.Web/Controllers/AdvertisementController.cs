using Microsoft.AspNetCore.Mvc;
using ThingsSales.Service.IService;

namespace ThingsSales.Web.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAdvertismentService _advertismentService;

        public AdvertisementController(IAdvertismentService advertismentService)
        {
            _advertismentService = advertismentService;
        }

        public async Task<IActionResult> Index(int itemId)
        {
            var advertisment = await _advertismentService.GetItemById(itemId);

            return View(advertisment);
        }
    }
}
