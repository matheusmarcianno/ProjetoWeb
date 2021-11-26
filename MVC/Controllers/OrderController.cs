using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> InsertOrder(Order order, List<Plate> plates, int clientId)
        {
            var result = await this._orderService.InsertAsync(order, plates, clientId);
            if (!result.Success)
            {
                return ViewBag.Errors = result;
            }

            return RedirectToAction();
        }


    }
}
