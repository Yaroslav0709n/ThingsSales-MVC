using Microsoft.AspNetCore.Mvc;
using ThingsSales.Service.IService;
using ThingsSales.Service.Service;
using ThingsSales.Service.ViewModels;

namespace ThingsSales.Web.Controllers
{
    public class ItemController : Controller
    {
        private readonly IAdvertismentService _itemService;
        private readonly IUserService _userService;

        public ItemController(IAdvertismentService advertismentService,
                                       IUserService userService)
        {
            _itemService = advertismentService;
            _userService = userService;
        }

        // GET 

        public async Task<IActionResult> GetUserItemById(int itemId)
        {
            string userId = HttpContext.Session.GetString("UserId");

            var advertisement = await _itemService.GetItemById(itemId);
            var user = await _userService.GetUserById(userId);

            var advertisementUser = new ItemUserViewModel()
            {
                ItemModel = advertisement,
                UserModel = user,
            };

            return View(advertisementUser);
        }

        [HttpGet]
        public async Task<ActionResult> GetUserItems()
        {
            string userId = HttpContext.Session.GetString("UserId");

            var items = await _itemService.GetAllUserItemsById(userId);

            return View(items);
        }

        public async Task<IActionResult> CreateItem()
        {
            return View();
        }

        // POST

        [HttpPost]
        public async Task<ActionResult> CreateItem(ItemViewModel item, List<IFormFile> photos)
        {
            string userId = HttpContext.Session.GetString("UserId");

            await _itemService.InsertItem(item, photos, userId);

            return RedirectToAction("GetUserItems", "Item");
        }
    }
}
