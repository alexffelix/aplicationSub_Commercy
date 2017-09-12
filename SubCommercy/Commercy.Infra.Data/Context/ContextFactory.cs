using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commercy.Infra.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<CommercyContext>
    {
        public CommercyContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CommercyContext>();
            builder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projetos\\Subway\\Fonte\\SubCommercy\\Commercy.Infra.Data\\DataBase\\CommercyDB.mdf;Integrated Security=True;Connect Timeout=30");
            return new CommercyContext(builder.Options);
        }
    }
}
