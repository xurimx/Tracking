using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Tracking.Data;

namespace Tracking.Migration.Runner
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (host)
            {
                var context = host.Services.GetRequiredService<TrackingDbContext>();
                var logger = host.Services.GetRequiredService<ILogger<Program>>();

                logger.LogInformation("Runnng the migration.");

                context.Database.Migrate();

                logger.LogInformation("Migrations were ran.");

                await host.StopAsync();

                logger.LogInformation("Runner was successfully stopped.");
            }

            return 1;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var config = hostContext.Configuration;
                    services.AddDbContext<TrackingDbContext>(options => {
                        options.UseNpgsql(config.GetConnectionString("DefaultConnection"));
                    });
                });
    }
}
