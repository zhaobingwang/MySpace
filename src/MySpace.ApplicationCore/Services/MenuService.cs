using MySpace.ApplicationCore.Entities.MenuAggregate;
using MySpace.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySpace.ApplicationCore.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IAppLogger<MenuService> _logger;
        public MenuService(IMenuRepository menuRepository, IAppLogger<MenuService> logger)
        {
            _menuRepository = menuRepository;
            _logger = logger;
        }

        public async Task<ListPageResult<Menu>> ListPageAsync(int pageNumber, int pageSize)
        {
            return await _menuRepository.ListPageAsync(pageNumber, pageSize);
        }
    }
}
