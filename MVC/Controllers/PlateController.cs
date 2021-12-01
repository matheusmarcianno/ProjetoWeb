using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class PlateController : Controller
    {
        private readonly IPlateService _plateService;

        public PlateController(IPlateService plateService)
        {
            _plateService = plateService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var id = 2;
            //var plateDetails = await this.PlateDetails(id);

            //var insertPlate = await this.RegisterPlate(new Plate()
            //{
            //    Name = "30 peças de sushi",
            //    Description = "10 urumakes filadélfia, 10 uruamakes kani e 10 urumake califórnia",
            //    Price = 55.90,
            //    CategoryId = 2,
            //    RestaurantId = 3
            //});

            //var editPlate = await this.EditPlate(new Plate()
            //{
            //    Id = 2,
            //    Name = "Combo de sushi",
            //    Description = "30 peças de sushi sendo 10 urumakes filadélfia, 10 uruamakes kani e 10 urumake califórnia",
            //    Price = 50,
            //    CategoryId = 2,
            //    RestaurantId = 3
            //});

            //var deletePlate = await this.DeletePlate(new Plate()
            //{
            //    Id = 2,
            //    Name = "Combo de sushi",
            //    Description = "30 peças de sushi sendo 10 urumakes filadélfia, 10 uruamakes kani e 10 urumake califórnia",
            //    Price = 50,
            //    CategoryId = 2,
            //    RestaurantId = 3
            //});

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PlateDetails(Plate plate)
        {
            var plateDetails = await _plateService.GetByIdAsync(plate.Id);
            return View(plateDetails); 
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPlate(Plate plate)
        {
            var result = await _plateService.InsertAsync(plate);
            if (!result.Success)
            {
                ViewBag.Error = result;
                return View();
            }

            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlate(Plate plate)
        {
            await _plateService.DeleteAsync(plate);
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> EditPlate(Plate plate)
        {
            var result = await _plateService.UpdateAsync(plate);
            if (!result.Success)
            {
                ViewBag.Erroe = result;
                return View();
            }
            return View(plate);
        }
    }
}
