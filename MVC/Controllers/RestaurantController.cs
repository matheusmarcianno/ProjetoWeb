using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    // Objeto Controller que vai ser resposável por gerenciar a tela de cadastro de Restaurant,
    // que deve conter todos os campos presentes no "RestaurantRegisterModel".
    public class RestaurantController : Controller      
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IUserService _userService;
        private readonly IPlateService _plateService;

        public RestaurantController(IRestaurantService restaurantService, IUserService userService, IPlateService plateService)
        {
            _restaurantService = restaurantService;
            _userService = userService;
            _plateService = plateService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RestaurantRegisterModel registerModel)
        {
            var restaurant = registerModel.ConvertToRestaurant();
            var user = registerModel.ConvertToUser();

            var restaurantResult = await this._restaurantService.InsertAsync(restaurant);
            if (!restaurantResult.Success)
                return ViewBag.Error = restaurantResult;

            user.SetRestaurant(restaurantResult.Value.Id);

            var userResult = await this._userService.InsertAsync(user);
            if (!userResult.Success)
            {
                ViewBag.Error = userResult;
                return View();
            }

            return RedirectToAction("SignIn", "User");
        }
    }
}
