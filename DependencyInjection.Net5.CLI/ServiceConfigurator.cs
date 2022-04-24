using DependencyInjection.Net5.CLI.Services.HelloService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace DependencyInjection.Net5.CLI
{
    internal static class ServiceConfigurator
    {
        internal static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    //add your service registrations
                    services
                        .AddHelloServiceCore()
                        .AddHelloServicePorts();
                });

            return hostBuilder;
        }
    }
}
