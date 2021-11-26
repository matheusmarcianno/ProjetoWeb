using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("GetRestaurantPlates");
            }
            return RedirectToAction("SignIn", "User");
        }

        public async Task<IActionResult> GetPlatesRestaurant(Restaurant restaurant)
        {
            var restaurantPlates = await _restaurantService.GetPlates(restaurant);
            return View(restaurantPlates);
        }

        public async Task<IActionResult> SearchPlate(string search, Restaurant restaurant)
        {
            var plate = await _plateService.Search(search, restaurant.Id);
            return View(plate);
        }
    }
}
