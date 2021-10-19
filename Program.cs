using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace nursery
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Information("Getting the motors running...");

            CreateHost(args);
        }

        private static void CreateHost(string[] args)
        {
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (System.Exception ex)
            {
                Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
                GC.Collect();
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel(x => x.AddServerHeader = false)
                        .UseStartup<Startup>()
                        .UseUrls("http://localhost:5003");
                })
                .ConfigureAppConfiguration(configuration =>
                {
                    var currentEnv =
                        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json";

                    configuration
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", false, true)
                        .AddJsonFile(currentEnv, true);
                })
                .UseSerilog();
    }
}