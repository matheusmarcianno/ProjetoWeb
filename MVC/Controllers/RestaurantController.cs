using Domain.interfaces;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class RestaurantController : Controller      
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IUserService _userService;

        public RestaurantController(IRestaurantService restaurantService, IUserService userService)
        {
            this._restaurantService = restaurantService;
            this._userService = userService;
        }

        [HttpPost("regiter")]
        public async Task<IActionResult> Post(RestaurantRegisterModel registerModel)
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

            //TODO: direcionar...
            return RedirectToAction("Index", "SignIn");
        }
    }
}
