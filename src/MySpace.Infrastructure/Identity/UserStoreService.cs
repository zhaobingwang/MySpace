using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace MySpace.Infrastructure.Identity
{
    public class UserStoreService : UserStore
    {
        private readonly AppIdentityDbContext _dbContext;
        public UserStoreService(AppIdentityDbContext dbContext, IdentityErrorDescriber describer = null) : base(dbContext, describer)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUserPageResult> GetPagesAsync(int pageNumber, int pageCount)
        {
            var totalCount = await _dbContext.Users.CountAsync();
            var pageUsers = _dbContext.Users.Skip((pageNumber - 1) * pageCount).Take(pageCount);
            return new ApplicationUserPageResult
            {
                TotalCount = totalCount,
                CurrentPageUsers = pageUsers
            };
        }
    }

    public class ApplicationUserPageResult
    {
        public int TotalCount { get; set; }
        public IEnumerable<ApplicationUser> CurrentPageUsers { get; set; }
    }
}
