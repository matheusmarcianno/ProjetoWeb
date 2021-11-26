﻿using Domain.Entities;
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
        private readonly ICategoryService _categoryService;


        public HomeController(ILogger<HomeController> logger, IPlateService plateService, ICategoryService categoryService)
        {
            _logger = logger;
            _plateService = plateService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("GetPlate");
            }
            return RedirectToAction("SignIn", "User");
        }

        public async Task<IActionResult> GetPLates( )
        {
            var plates = await _plateService.GetAllAsync();
            return View(plates);
        }

        // mostra todas as categorias disponiveis
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _plateService.GetAllAsync();
            return View(categories);
        }

        // TODO: Implementar o método que recomendará pratos ao usuário com base em seus últimos pedidos utilizadno a IA

        public async Task<IActionResult> GetCategoryPlates(Category category)
        {
            var categoryPlates = await _categoryService.GetPlates(category);
            return View(categoryPlates);
        }

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
