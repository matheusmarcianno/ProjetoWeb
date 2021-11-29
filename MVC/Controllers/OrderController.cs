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

        public OrderController(IOrderService orderService, IClientService clientService)
        {
            this._orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterOrder(Order order, List<Plate> plates, int clientId)
        {
            var result = await this._orderService.InsertAsync(order, plates, clientId);
            if (!result.Success)
            {
                return ViewBag.Errors = result;
            }

            return View(result);
        }
    }
}
