using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpace.ApplicationCore.Entities.TPAppsAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpace.Infrastructure.Data.EntityConfigurations
{
    public class AppPasswordConfiguration : IEntityTypeConfiguration<TPAppPassword>
    {
        public void Configure(EntityTypeBuilder<TPAppPassword> builder)
        {
            builder.Property(b => b.CurrentPasswordHash)
                .IsRequired(true);
            builder.Property(b => b.CreateTime)
                .IsRequired(true);
            builder.Property(b => b.ModifyTime)
                .IsRequired(true);
        }
    }
}
