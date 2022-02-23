using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DataAccessLibrary.Models;

namespace DataAccessLibrary.DataAccess
{
    public class WeatherDataDbContext : DbContext
    {
        public DbSet<WeatherDataModel> WeatherData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var config = builder.Build();


            options.UseSqlServer(config.GetConnectionString("Default"));
        }
    }
}
