using Microsoft.AspNetCore.Mvc;
using ThingsSales.Service.IService;
using ThingsSales.Service.Service;

namespace ThingsSales.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertismentService _itemService;

        public HomeController(IAdvertismentService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult> GetItems()
        {
            var items = await _itemService.GetAllItems();

            return View(items);
        }


    }
}
