using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySpace.Infrastructure.Identity;

namespace MySpace.WebMvc
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
        }

        #region ��������
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            CommonConfigureService(services);
            // Razor �ļ�����
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            CommonConfigure(app);
        }
        #endregion

        #region ��������
        public void ConfigureProductionServices(IServiceCollection services)
        {
            CommonConfigureService(services);
            services.AddControllersWithViews();
        }

        public void ConfigureProductionDevelopment(IApplicationBuilder app)
        {
            CommonConfigure(app);
        }
        #endregion

        #region ����ע���HTTP����ܵ�����
        /// <summary>
        /// ����������ķ���ע��
        /// </summary>
        /// <param name="services"></param>
        public void CommonConfigureService(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("IdentityConncetion")));

            ConfigureIdentityService(services);
        }

        /// <summary>
        /// �����������HTTP����ܵ�����
        /// </summary>
        /// <param name="app"></param>
        private void CommonConfigure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        /// <summary>
        /// ���ASP.NET Core Identity���񵽷���������
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureIdentityService(IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies(o => { });
        }
        #endregion

        #region snippet
        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddControllersWithViews();
        //}

        //// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //        app.UseHsts();
        //    }
        //    app.UseHttpsRedirection();
        //    app.UseStaticFiles();

        //    app.UseRouting();

        //    app.UseAuthentication();
        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Home}/{action=Index}/{id?}");
        //    });
        //}
        #endregion
    }
}
