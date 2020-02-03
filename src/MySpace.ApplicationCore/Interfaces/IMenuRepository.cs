using MySpace.ApplicationCore.Entities.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MySpace.ApplicationCore.Interfaces
{
    public interface IMenuRepository : IRepository<Menu>
    {
        Task<ListPageResult<Menu>> ListPageAsync(int pageNumber, int pageSize);
    }
}
