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
            this._clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertClien(Client client)
        {
            var result = await this._clientService.InsertAsync(client);
            if (!result.Success)
                return ViewBag.Error(result.Message);

            return RedirectToAction("InsertUser");
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(User user, int clientId)
        {
            var result = await this._userService.InsertAsync(user, clientId);
            if (!result.Success)
                return ViewBag.Erros(result);

            return RedirectToAction("Index", "Home");
        }
    }
}
