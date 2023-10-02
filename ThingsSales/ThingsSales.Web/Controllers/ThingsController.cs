using Microsoft.AspNetCore.Mvc;

namespace ThingsSales.Web.Controllers
{
    public class ThingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
