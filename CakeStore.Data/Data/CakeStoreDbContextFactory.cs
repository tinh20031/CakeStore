using CakeStoreAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Data.Data
{
    public class CakeStoreDbContextFactory : IDesignTimeDbContextFactory<CakeStoreDbContext>
    {
        public CakeStoreDbContext CreateDbContext(string[] args)
        {
           
            var basePath = Directory.GetParent(Directory.GetCurrentDirectory())?.FullName;
            var apiProjectPath = Path.Combine(basePath, "CakeStoreAPI"); 

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(apiProjectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("PgDbConnection");

            var optionsBuilder = new DbContextOptionsBuilder<CakeStoreDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new CakeStoreDbContext(optionsBuilder.Options);
        }
    }
}
