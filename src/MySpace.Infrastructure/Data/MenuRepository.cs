using MySpace.ApplicationCore.Entities.MenuAggregate;
using MySpace.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace MySpace.Infrastructure.Data
{
    public class MenuRepository : EFRepository<Menu>, IMenuRepository
    {
        public MenuRepository(MySpaceDbContext dbContext) : base(dbContext)
        {
        }
    }
}
