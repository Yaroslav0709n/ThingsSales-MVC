using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThingsSales.Data.Common.Exception;
using ThingsSales.Data.ContextData;
using ThingsSales.Model.Auth;
using ThingsSales.Model.Identity;

namespace ThingsSales.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AuthController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(Register register)
        {
            if (!string.IsNullOrEmpty(register.Email))
            {
                await _userManager.FindByEmailAsync(register.Email);
            }
            else
                return BadRequest("Email is taken");

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                UserName = register.Email,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
                City = register.City,
            };

            if (!string.IsNullOrEmpty(register.Email))
            {
                var result = await _userManager.CreateAsync(user, register.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return BadRequest(ModelState);
                }
            }

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email))
                return BadRequest(new ErrorResponse { Error = "Email is required" });
            
            if (string.IsNullOrEmpty(login.Password))
                return BadRequest(new ErrorResponse { Error = "Password is required" });
            
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
                return BadRequest(new ErrorResponse { Error = "Invalid email" });

            if (!await _userManager.CheckPasswordAsync(user, login.Password))
                return BadRequest(new ErrorResponse { Error = "Invalid password" });

            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.Id);
                HttpContext.Session.SetString("UserFullName", $"{user.FirstName} {user.LastName}");
            }

            return RedirectToAction("Index", "Things");
        }
    }
}
