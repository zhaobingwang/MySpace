using Microsoft.Extensions.Logging;
using MySpace.ApplicationCore.Entities.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySpace.Infrastructure.Data
{
    public class MySpaceDbContextSeed
    {
        public static async Task SeedDataAsync(MySpaceDbContext dbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!dbContext.Menus.Any())
                {
                    dbContext.Menus.AddRange(GetMenus());
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<MySpaceDbContextSeed>();
                    log.LogError(ex.Message);
                    await SeedDataAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<Menu> GetMenus()
        {
            var now = DateTimeOffset.Now;
            return new List<Menu>()
            {
                new Menu() {Name="菜单管理",Remark="菜单管理",ParentId=0,IsShow=1,Url="",Icon="fa fa-bars",CreateTime=now,ModifyTime=now},
                new Menu() {Name="菜单列表",Remark="菜单列表",ParentId=1,IsShow=1,Url="/console/menu",Icon="",CreateTime=now,ModifyTime=now}
            };
        }
    }
}
