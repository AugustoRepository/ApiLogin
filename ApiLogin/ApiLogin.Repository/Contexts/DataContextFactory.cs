using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ApiLogin.Repository.Contexts
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var root = configurationBuilder.Build();

            var connectionStringd = root.GetSection("ConnectionStrings").GetSection("LoginApiDb").Value;
            var builder = new DbContextOptionsBuilder<DataContext>();

            builder.UseSqlServer(connectionStringd);
            return new DataContext(builder.Options);

        }
    }
}
