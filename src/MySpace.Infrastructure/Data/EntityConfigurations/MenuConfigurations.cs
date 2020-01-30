using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpace.ApplicationCore.Entities.MenuAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.Infrastructure.Data.EntityConfigurations
{
    public class MenuConfigurations : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("SysMenus");

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(16);
            builder.Property(b => b.Remark)
                .HasMaxLength(256);
            builder.Property(b => b.ParentId)
                .IsRequired()
                .HasDefaultValue(0);
            builder.Property(b => b.IsShow)
                .IsRequired()
                .HasDefaultValue(0);
            builder.Property(b => b.Url)
                .HasMaxLength(1024);
            builder.Property(b => b.Icon)
                .HasMaxLength(64);
            builder.Property(b => b.CreateTime)
                .IsRequired();
            builder.Property(b => b.ModifyTime)
                .IsRequired();
        }
    }
}