using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    // Objeto Controller que vai ser resposável por gerenciar a tela de cadastro de clientes,
    // que deve conter todos os campos presentes no "ClientRegisterModel".
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;

        public ClientController(IClientService clientService, IUserService userService)
        {
            this._clientService = clientService;    
            this._userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(ClientRegisterModel registerModel)
        {
            var client = registerModel.ConvertToClient();
            var user = registerModel.ConvertToUser();

            var clientInsertResult = await this._clientService.InsertAsync(client);
            if (!clientInsertResult.Success)
                return ViewBag.Error = clientInsertResult;

            user.SetClient(clientInsertResult.Value.Id);

            var userInsertResult = await this._userService.InsertAsync(user);
            if (!userInsertResult.Success) 
                return ViewBag.Error = userInsertResult;

            return RedirectToAction("SignIn", "User");
        }
    }
}
