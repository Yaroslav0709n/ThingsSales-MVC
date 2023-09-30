using Microsoft.AspNetCore.Mvc;

namespace ThingsSales.Web.Controllers
{
    public class ThingsController : Controller
    {
        public IActionResult Things()
        {
            return View();
        }
    }
}
