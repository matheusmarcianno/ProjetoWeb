using Domain.Entities;
using Domain.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IClientService _clientService;

        public UserController(IUserService userService, IClientService clientService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
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
        public async Task<IActionResult> Post(User user)
        {
            var userResult = await this._userService.Authenticate(user);
            if (!userResult.Success)
            {
                ViewBag.Error = userResult;
                return View();
            }

            //TODO: Terminar este método.
            return View();
        }
    }
}
