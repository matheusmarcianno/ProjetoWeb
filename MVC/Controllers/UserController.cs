using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IClientService clientService)
        {
            this._userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> User(int id)
        {
            var userResult = await this._userService.GetByIdAsync(id);
            if (!userResult.Success)
            {
                ViewBag.Error = userResult; 
                return View();
            }

            return View(userResult);
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(User user)
        {
            var result = await _userService.Authenticate(user);

            var role = "";
            if (result.Value.RestaurantId.HasValue)
                role = "Restaurant";
            else
                role = "Client";

            if (result.Success)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, role)
                };
                var claimIndentity = new ClaimsIdentity(userClaims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIndentity));

                if (role == "Restaurant")
                    return RedirectToAction("Index", "HomeRestaurant");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "e-mail e(ou) senha inválido(os)";
            return View();
        }
    }
}
