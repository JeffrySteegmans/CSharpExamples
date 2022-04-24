using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SeriLog.Net5.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = ServiceConfigurator
                .CreateHostBuilder(args)
                .Build();

            var logger = host.Services.GetService<ILogger<Program>>();

            logger.LogInformation("Hello world");
        }
    }
}
