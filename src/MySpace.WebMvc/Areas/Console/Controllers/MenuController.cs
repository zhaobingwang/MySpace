using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySpace.ApplicationCore.Interfaces;

namespace MySpace.WebMvc.Areas.Console.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public class MenuController : ConsoleBaseController
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IAppLogger<MenuController> _logger;
        public MenuController(IMenuRepository menuRepository, IAppLogger<MenuController> logger)
        {
            _menuRepository = menuRepository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexV2()
        {
            return View();
        }

        [HttpGet("console/menu/list-page")]
        public async Task<IActionResult> ListPage(int offset, int limit)
        {
            var menus = await _menuRepository.ListPageAsync(offset + 1, limit);
            return Json(menus);
        }
    }
}