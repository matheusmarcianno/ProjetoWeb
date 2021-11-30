using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryServie)
        {
            _categoryService = categoryServie;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var insertCategory = await this.RegisterCategory(new Category()
            {
                Name = "Japonesa"
            });

            return View();
        }

        /// <summary>
        /// Método responsável por inserir uma nova categoria no site.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> RegisterCategory(Category category)
        {
            var result = await _categoryService.InsertAsync(category);
            if (!result.Success)
            {
                ViewBag.Error = result;
                return View();
            }

            return View();
        }
    }
}
