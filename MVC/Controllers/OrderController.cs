using Domain.Entities;
using Domain.Enum;
using Domain.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;

        public OrderController(IOrderService orderService, IClientService clientService)
        {
            this._orderService = orderService;
            this._clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder()
        {
            var order = new Order()
            {
                Id = 1,
                Status = Status.Finalizado,
                Client = new Client()
                {       
                    Id = 1,
                    Name = "Matheus Marciano",
                    BirthDate = DateTime.Now,
                    Cpf = "09679837971",
                    PhoneNumber = "47996886929",
                    Orders = new List<Order>()
                },
                Plates = new List<Plate>()
            };

            var plates = new List<Plate>();
            var clientId = 1;

            var result = await this._orderService.InsertAsync(order, plates, clientId);
            if (!result.Success)
            {
                return ViewBag.Errors(result);
            }

            return RedirectToAction();
        }
    }
}
