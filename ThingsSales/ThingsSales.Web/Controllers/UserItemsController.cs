using Microsoft.AspNetCore.Mvc;

namespace ThingsSales.Web.Controllers
{
    public class UserItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
