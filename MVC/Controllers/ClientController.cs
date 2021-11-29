﻿using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;

        public ClientController(IClientService clientService, IUserService userService)
        {
            this._clientService = clientService;    
            this._userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var insertClient = await this.SignUp(new ClientRegisterModel()
            {
                Emial = "matheus@gmail.com",
                Password = "1234",
                Name = "Matheus V",
                Cpf = "09679837971",
                Cep = "89037700",
                PhoneNumber = "47996886829",
                BirthDate = DateTime.Now
            });

            return View();
        }

        /// <summary>
        /// Método responsável por inserir um novo cliente e um novo usuário ao mesmo tempo no site. 
        /// Logo após a inserção, o método retorna um novo caminho para "SignIn" -> "UserController",
        /// possibilitando o Login do usuário.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SignUp(ClientRegisterModel registerModel)
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

    // pegar um prato que o cliente selecionou e adicioná-lo no carrinho
    // trazer o pedido feito pelo cliente para que o restaurante o venha aceitar ou recusar.
    // fazer o método que recomenda ao cliente pratos com base nos últimos pedidos que ele fez.

}
