using Commercy.Infra.Data.Extensions;
using CommercyDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercy.Infra.Data.Configuration
{
    public class ShoppingExecutedConfig : EntityTypeConfiguration<ShoppingExecuted>
    {
        public override void Map(EntityTypeBuilder<ShoppingExecuted> builder)
        {
            

            builder.HasKey(c => c.ShoppingExecutedId);

            builder.Property(c => c.StatusShopping)
                .HasColumnType("bit")
                .HasDefaultValue(1)
                .IsRequired();

            builder.Property(c => c.TotalShopping)
                .HasColumnType("Money")
                .IsRequired();

        }
    }
}
