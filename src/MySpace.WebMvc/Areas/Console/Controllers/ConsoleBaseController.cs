using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MySpace.WebMvc.Areas.Console.Controllers
{
    [Authorize]
    [Area("Console")]
    public class ConsoleBaseController : Controller
    {
        public ConsoleBaseController()
        {
        }
    }
}
