using Customer.API.Extensions;
using Customer.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customer.API
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build()
                             .MigrateDatabase<CustomerContext>((context, services) =>
                             {
                               var logger = services.GetService<ILogger<CustomerContextSeed>>();
                               CustomerContextSeed
                                    .SeedAsync(context, logger)
                                    .Wait();
                             })
                             .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
            });
  }
}
