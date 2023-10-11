using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThingsSales.Model;
using ThingsSales.Service.IService;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Web.Controllers
{
    public class UserItemsController : Controller
    {
        private readonly IItemService _itemService;

        public UserItemsController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public async Task<ActionResult> Index()
        {
            string userId = HttpContext.Session.GetString("UserId");

            var items = await _itemService.GetAllItems(userId);
            return View(items);
        }

        [HttpPost]
        public async Task<ActionResult> InsertItem(ItemViewModel item, List<IFormFile> photos)
        {
            string userId = HttpContext.Session.GetString("UserId");

            await _itemService.InsertItem(item, photos, userId);

            return RedirectToAction("Index", "UserItems");
        }

    }
}
