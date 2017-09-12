using Commercy.Infra.Data.Extensions;
using CommercyDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercy.Infra.Data.Configuration
{
    public class AccountShoppingConfig : EntityTypeConfiguration<AccountShopping>
    {
        public override void Map(EntityTypeBuilder<AccountShopping> builder)
        {
            builder.HasKey(c => c.AccountShoppingId);

            builder.Property(c => c.ActiveAccountShopping)
                .HasColumnType("bit")
                .HasDefaultValue(1)
                .IsRequired();


        }
    }
}
