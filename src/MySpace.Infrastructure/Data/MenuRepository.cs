using MySpace.ApplicationCore.Entities.MenuAggregate;
using MySpace.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MySpace.ApplicationCore;
using Microsoft.EntityFrameworkCore;

namespace MySpace.Infrastructure.Data
{
    public class MenuRepository : EFRepository<Menu>, IMenuRepository
    {
        public MenuRepository(MySpaceDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ListPageResult<Menu>> ListPageAsync(int pageNumber, int pageSize)
        {
            var totalCount = await _dbContext.Menus.CountAsync();
            var menus = _dbContext.Menus.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return new ListPageResult<Menu>
            {
                total = totalCount,
                rows = menus,
            };
        }
    }
}
