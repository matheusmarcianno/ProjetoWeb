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
        public async Task<IActionResult> PlateDetails(Plate plate)
        {
            var plateDetails = await _plateService.GetByIdAsync(plate.Id);
            return View(plate); 

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
        public async Task<IActionResult> DeleteAsync(Plate plate)
        {
            await _plateService.DeleteAsync(plate);
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Plate plate)
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
