using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpace.ApplicationCore.Entities.TPAppsAggregate;

namespace MySpace.Infrastructure.Data.EntityConfigurations
{
    public class AppConfiguration : IEntityTypeConfiguration<TPApp>
    {
        public void Configure(EntityTypeBuilder<TPApp> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(TPApp.Password));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(b => b.Remark)
                .HasMaxLength(256);
            builder.Property(b => b.CreateTime)
                .IsRequired();
            builder.Property(b => b.ModifyTime)
                .IsRequired();
        }
    }
}
