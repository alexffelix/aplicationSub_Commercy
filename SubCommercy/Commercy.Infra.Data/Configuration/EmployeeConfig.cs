using Commercy.Infra.Data.Extensions;
using CommercyDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercy.Infra.Data.Configuration
{
    public class EmployeeConfig : EntityTypeConfiguration<Employee>
    {
        public override void Map(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(c => c.EmployeeId);

            builder.Property(c => c.EmployeeName)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

        }
    }
}
