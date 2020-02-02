using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySpace.Infrastructure.Identity;
using MySpace.WebMvc.Areas.Console.Models.AccountViewModel;
using System.Threading.Tasks;

namespace MySpace.WebMvc.Areas.Console.Controllers
{
    /// <summary>
    /// 用户账号管理
    /// </summary>
    public class AccountManageController : ConsoleBaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserStoreService _userStoreService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public AccountManageController(UserStoreService userStoreService, UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory, IMapper mapper)
        {
            _userManager = userManager;
            _userStoreService = userStoreService;
            _logger = loggerFactory.CreateLogger<AccountManageController>();
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var users = await _userStoreService.GetPagesAsync(1, 10);
            var vm = _mapper.Map<UserPagesViewModel>(users);
            return View(vm);
        }
    }
}