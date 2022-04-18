using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmergencyLog.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmergencyLog.Api
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //var host = CreateHostBuilder(args).Build();

            //using var scope = host.Services.CreateScope();

            //var services = scope.ServiceProvider;

            //try
            //{
            //    var context = services.GetRequiredService<DataContext>();
            //    await context.Database.MigrateAsync();
            //    Seed.SeedData(context);
            //}
            //catch (Exception ex)
            //{
            //    var logger = services.GetRequiredService<ILogger<Program>>();
            //    logger.LogError(ex, "An error occurred during migration");
            //}

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
