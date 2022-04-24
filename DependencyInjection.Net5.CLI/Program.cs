using DependencyInjection.Net5.CLI.Services.HelloService;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Net5.CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var host = ServiceConfigurator
                .CreateHostBuilder(args)
                .Build();

            var helloService = host.Services.GetService<IHelloService>();
            helloService.WriteMessage();
        }
    }
}
