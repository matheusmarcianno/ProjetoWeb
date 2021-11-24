using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Get(Category category)
        {
            var categories = await this._categoryService.GetAllAsync();
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> InsertCategory(Category category)
        {
            var result = await _categoryService.InsertAsync(category);
            if (!result.Success)
            {
                ViewBag.Error = result;
                return View();
            }

            return RedirectToAction();
        }
    }
}
