using Microsoft.AspNetCore.Mvc;
using MySpace.ApplicationCore.Interfaces;
using System.Threading.Tasks;

namespace MySpace.WebMvc.Areas.Console.Controllers
{
    public class HomeController : ConsoleBaseController
    {
        private readonly IMenuRepository _menuRepository;
        public HomeController(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<IActionResult> Index()
        {
            var menus = await _menuRepository.ListAllAsync();
            return View(menus);
        }
    }
}