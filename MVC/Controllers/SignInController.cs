using Domain.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class SignInController : Controller
    {
        private readonly IUserService _userService;

        public SignInController(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
