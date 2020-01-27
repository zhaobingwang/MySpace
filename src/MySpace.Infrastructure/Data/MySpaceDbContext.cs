using Microsoft.EntityFrameworkCore;
using MySpace.ApplicationCore.Entities.TPAppsAggregate;
using System.Reflection;

namespace MySpace.Infrastructure.Data
{
    public class MySpaceDbContext : DbContext
    {
        public MySpaceDbContext(DbContextOptions<MySpaceDbContext> options) : base(options)
        {

        }
        public DbSet<TPApp> Apps { get; set; }
        public DbSet<TPAppPassword> AppPasswords { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //builder.ApplyConfiguration(new PasswordConfiguration());
            //builder.ApplyConfiguration(new PasswordAppConfiguration());
        }
    }
}
