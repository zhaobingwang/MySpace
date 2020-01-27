using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySpace.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MySpace.WebMvc
{
    public class SeedData
    {
        public static void EnsureSeedIdentityData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });

            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<AppIdentityDbContext>();
                    context.Database.Migrate();

                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    var zhangsan = userManager.FindByNameAsync("zhangsan").Result;
                    if (zhangsan == null)
                    {
                        zhangsan = new ApplicationUser
                        {
                            UserName = "zhangsan",
                            Email = "zhangsan@email.com"
                        };
                        var result = userManager.CreateAsync(zhangsan, "123456").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        result = userManager.AddClaimsAsync(zhangsan, new Claim[] {
                            new Claim("name", "张三"),
                            new Claim("given_name", "三"),
                            new Claim("family_name", "张"),
                            new Claim("email", "zhangsan@email.com"),
                            new Claim("email_verified", "true", ClaimValueTypes.Boolean),
                            new Claim("website", "http://zhangsan.com"),
                            new Claim("address", @"{ '城市': '杭州', '邮政编码': '310000' }","json")
                        }).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                    }

                    var lisi = userManager.FindByNameAsync("lisi").Result;
                    if (lisi == null)
                    {
                        lisi = new ApplicationUser
                        {
                            UserName = "lisi",
                            Email = "lisi@email.com"
                        };
                        var result = userManager.CreateAsync(lisi, "123456").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                        result = userManager.AddClaimsAsync(zhangsan, new Claim[] {
                            new Claim("name", "李四"),
                            new Claim("given_name", "四"),
                            new Claim("family_name", "李"),
                            new Claim("email", "lisi@email.com"),
                            new Claim("email_verified", "true", ClaimValueTypes.Boolean),
                            new Claim("", "http://bob.com"),
                            new Claim("website", @"{ '城市': '上海', '邮政编码': '200000' }","json")
                        }).Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                    }
                }
            }
        }

        public static void EnsureSeedAppData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {

                }
            }
        }
    }
}
