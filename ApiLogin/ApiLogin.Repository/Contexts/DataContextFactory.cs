﻿using Microsoft.EntityFrameworkCore;
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
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("connectionStrings").GetSection("HortoHouse").Value;
            var builder = new DbContextOptionsBuilder<DataContext>();

            builder.UseSqlServer(connectionString);
            return new DataContext(builder.Options);

        }
    }
}
