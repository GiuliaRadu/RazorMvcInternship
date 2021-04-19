using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RazorMvc.Data;

namespace RazorMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            bool recreateDb = args.Contains("--recreateDb");
            InitializeDb(host, recreateDb);

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });

        private static void InitializeDb(IHost host, bool recreateDb)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                {
                    var context = services.GetRequiredService<InternDbContext>();
                    var webHostEnvironment = services.GetRequiredService<IWebHostEnvironment>();
                    if (webHostEnvironment.IsDevelopment() && recreateDb)
                    {
                        logger.LogDebug("User requested to recreate database.");
                        context.Database.EnsureDeleted();
                        logger.LogWarning("The database was removed.");
                    }

                    SeedData.Initialize(context);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }
    }
}
