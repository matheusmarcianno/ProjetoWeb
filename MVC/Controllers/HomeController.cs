using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
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
        private readonly IPlateService _plateService;

        public HomeController(ILogger<HomeController> logger, IPlateService plateService)
        {
            _logger = logger;
            _plateService = plateService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            { 
                return RedirectToAction("GetPlate");
            }
            else
                return View("SignIn", "User");
        }

        public async Task<IActionResult> GetPLates( )
        {
            await _plateService.GetAllAsync();
            return View();
        }

        public async Task<IActionResult> GetCategories()
        {
            await _plateService.GetAllAsync();
            return View();
        }
        //TODO: implementar um método que vai permitir pegar os pratos da categoria que o usuário selecionar.

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("SignIn", "User");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
