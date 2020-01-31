using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MySpace.WebMvc.Areas.Console.Controllers
{
    /// <summary>
    /// 菜单管理
    /// </summary>
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}