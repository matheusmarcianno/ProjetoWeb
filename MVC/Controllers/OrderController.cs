using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Index()
        {

            //var insertOrder = await this.RegisterOrder(new Order()
            //{
            //    ClientId = 1,
            //    RestaurantId = 3,
            //    Plates = new List<Plate>()
            //    {
            //        new Plate()
            //        {
            //            CategoryId = 1,
            //            Name = "Coxinha",
            //            Description = "Coxinha de 200 gramas recheada com frago e requeijão",
            //            Price = 8.5,
            //            RestaurantId = 2
            //        },
            //        new Plate()
            //        {
            //            CategoryId = 2,
            //            Name = "Combo de sushi",
            //            Description = "30 peças de sushi sendo 10 urumakes filadélfia, 10 uruamakes kani e 10 urumake califórnia",
            //            Price = 50,
            //            RestaurantId = 3
            //        },
            //    },
            //    Status = Status.Finalizado,
            //});

            //var orders = await this.Orders();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterOrder(Order order)
        {
            var result = await this._orderService.InsertAsync(order);
            if (!result.Success)
            {
                return ViewBag.Errors = result;
            }

            return View(result);
        }

        public async Task<IActionResult> Orders()
        {
            var orders = await this._orderService.GetAllAsync();
            return View(orders);
        }
    }
}
