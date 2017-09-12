using Commercy.Infra.Data.Configuration;
using Commercy.Infra.Data.Extensions;
using CommercyDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Commercy.Infra.Data.Context
{
    public class CommercyContext: DbContext
    {
        public CommercyContext(DbContextOptions<CommercyContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<AccountShopping> AccountShopping { get; set; }
        public DbSet<ShoppingExecuted> ShoppingExecuted { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.AddConfiguration(new EmployeeConfig());
            modelBuilder.AddConfiguration(new CustomerConfig());
            modelBuilder.AddConfiguration(new AccountShoppingConfig());

            modelBuilder.Entity<Customer>()
            .HasOne(us => us.AccountShopping)
            .WithOne(u => u.CustomerAccountShopping)
            .HasForeignKey<AccountShopping>(b => b.CustomerIdAccountShopping);

            modelBuilder.Entity<ShoppingExecuted>()
                .HasOne(p => p.AccountShoppingExecuted)
                .WithMany(b => b.LstShoppingExecuted);


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
