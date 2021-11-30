using Domain.Entities;
using Domain.Enum;
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
        public async Task<IActionResult> Index()
        {
            var insertOrder = await this.RegisterOrder(new Order()
            {
                ClientId = 1,
                RestaurantId = 3,
                Plates = new List<Plate>() 
                {
                    new Plate()
                    {
                         CategoryId = 2,
                         Name = "Macarrão",
                         Description = "Macarrão alho e óleo com molho branco",
                         Price = 18,
                    }, 
                    new Plate()
                    {
                         CategoryId = 1,
                         Name = "Coxinha",
                         Description = "Coxinha de frango de 200 gramas",
                         Price = 7,
                    },
                }, 
                Status = Status.Finalizado,
            }, 
            new List<Plate>(){ new Plate()
            , new Plate()}, 4);

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
