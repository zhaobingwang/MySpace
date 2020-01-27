using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySpace.Utilities.Security;

namespace MySpace.WebMvc.Controllers
{
    /// <summary>
    /// 密码管理
    /// </summary>
    public class PasswordController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 生成一个密码
        /// </summary>
        /// <returns></returns>
        public IActionResult Make(string appName)
        {
            var password = Password.Generate(10, 4);
            return View();
        }

        //private string MakeRandomPassword(bool)
        //{
        //}
    }
}