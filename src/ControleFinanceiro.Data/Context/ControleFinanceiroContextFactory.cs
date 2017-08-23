using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleFinanceiro.Data.Context
{
    public class ControleFinanceiroContextFactory : IDesignTimeDbContextFactory<ControleFinanceiroContext>
    {
     

        public ControleFinanceiroContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
            var basePath = AppContext.BaseDirectory;
            return Create(basePath, environmentName);
        }

        private ControleFinanceiroContext Create(string basePath, string environmentName)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environmentName}.json", true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            var connstr = config.GetConnectionString("DefaultConnection");

            if (String.IsNullOrWhiteSpace(connstr) == true)
                throw new InvalidOperationException("Could not find a connection string named '(default)'.");
            else            
                return Create(connstr);            
        }

        private ControleFinanceiroContext Create(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException(
                    $"{nameof(connectionString)} is null or empty.",
                    nameof(connectionString));

            var optionsBuilder = new DbContextOptionsBuilder<ControleFinanceiroContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new ControleFinanceiroContext(optionsBuilder.Options);
        }
    }        
}
