using Domain.Entities;
using Domain.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientService _clientService;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var clientInsertresult = await _clientService.InsertAsync(new Client()
            {
                Id = 1,
                Name = "Matheus Marciano",
                Cpf = "06979837971",
                BirthDate = DateTime.Now,
                PhoneNumber = "47996886829",
                Orders = new List<Order>()
            });

            if (!clientInsertresult.Success)
            {
                ViewBag.Error = clientInsertresult.Message;
                return View();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
