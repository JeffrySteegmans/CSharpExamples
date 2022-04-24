using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;

namespace SeriLog.Net5.CLI
{
    internal static class ServiceConfigurator
    {
        internal static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddEnvironmentVariables();

                    // Specifying the configuration for serilog
                    Log.Logger = new LoggerConfiguration() // initiate the logger configuration
                            .ReadFrom.Configuration(builder.Build()) // connect serilog to our configuration folder
                            .Enrich.FromLogContext() //Adds more information to our logs from built in Serilog 
                            .WriteTo.Console() // decide where the logs are going to be shown
                            .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day)
                            .CreateLogger(); //initialise the logger
                })
                .ConfigureServices((context, services) =>
                {
                    //add your service registrations
                })
                .UseSerilog();
            
            return hostBuilder;
        }
    }
}
