using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpace.ApplicationCore.Entities.MenuAggregate;
using MySpace.ApplicationCore.Interfaces;

namespace MySpace.WebMvc.Areas.Console.Controllers
{
    [Authorize]
    [Area("Console")]
    public class HomeController : Controller
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