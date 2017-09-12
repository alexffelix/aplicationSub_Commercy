using Commercy.Infra.Data.Extensions;
using CommercyDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercy.Infra.Data.Configuration
{
    public class CustomerConfig : EntityTypeConfiguration<Customer>
    {
        public override void Map(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerId);
            

            builder.Property(c => c.NameCustomer)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(c => c.NumberPersonalDocument)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(c => c.AddressCustomer)
                .HasColumnType("varchar(250)")
                .HasMaxLength(250)
                .IsRequired();

            
                

        }
    }
}
