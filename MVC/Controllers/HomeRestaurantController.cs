using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeRestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IPlateService _plateService;

        public HomeRestaurantController(IRestaurantService restaurantService, IPlateService plateService)
        {
            _restaurantService = restaurantService;
            _plateService = plateService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("SignIn", "User");
            }
            return RedirectToAction("Plates, HomeRestaurant");
        }

        /// <summary>
        /// Método que retorna todos os pratos que o restaurante tem cadastrado.
        /// </summary>
        public async Task<IActionResult> Plates(Restaurant restaurant)
        {
            var restaurantPlates = await _restaurantService.GetPlates(restaurant);
            return View(restaurantPlates);
        }

        /// <summary>
        /// Método responsável por buscar por um prato que o restaurante já tem cadastrado
        /// </summary>
        public async Task<IActionResult> Search(string search, Restaurant restaurant)
        {
            var plate = await _plateService.Search(search, restaurant.Id);
            return View(plate);
        }
    }
}
