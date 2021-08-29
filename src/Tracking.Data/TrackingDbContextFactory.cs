using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Tracking.Data
{
    public class TrackingDbContextFactory : IDesignTimeDbContextFactory<TrackingDbContext>
    {
        public TrackingDbContext CreateDbContext(string[] args)
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Tracking.Host"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TrackingDbContext>();

            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

            return new TrackingDbContext(optionsBuilder.Options);
        }
    }
}
