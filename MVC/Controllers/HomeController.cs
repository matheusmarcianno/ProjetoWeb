using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System.Diagnostics;
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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var categoryPlates = await this.CategoryPlates(new Category()
            //{
            //    Id = 2,
            //    Name = "Japonesa"
            //});
            //return View();

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");
            }
            return RedirectToAction("Plates");
        }

        /// <summary>
        /// Método que retorna todos os pratos disponíveis na Home do site.
        /// </summary>
        public async Task<IActionResult> Plates()
        {
            var plates = await _plateService.GetAllAsync();
            return View(plates);
        }

        /// <summary>
        /// Método que retorna todas as categorias na Home do site.
        /// </summary>
        public async Task<IActionResult> Categories()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }

        public async Task<IActionResult> Search(string search)
        {
            var searchResult = await _plateService.Search(search);
            return View(searchResult);
        }

        // TODO: Implementar o método que recomendará pratos ao usuário com base em seus últimos pedidos utilizadno a IA

        /// <summary>
        /// Método que retorna os pratos de uma determinada categoria selecionada pelo usuário.
        /// </summary>
        public async Task<IActionResult> CategoryPlates(Category category)
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
