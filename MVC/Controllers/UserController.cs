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

        [HttpGet]
        public async Task<IActionResult> GetUser(int id)
        {
            var userResult = await this._userService.GetByIdAsync(id);
            if (!userResult.Success)
            {
                ViewBag.Error = userResult; 
                return View();
            }

            return RedirectToAction();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(User user)
        {
            var result = await _userService.Authenticate(user);

            var role = "";
            if (result.Value.RestaurantId.HasValue)
            {
                role = "Restaurant";
            }
            else
            {
                role = "Client";
            }

            if (result.Success)
            {
                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Email),
                    new Claim(ClaimTypes.Role, role)
                };
                var claimIndentity = new ClaimsIdentity(userClaims, "Login");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIndentity));

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "e-mail e(ou) senha inválido(os)";
            return View();
        }
    }
}
