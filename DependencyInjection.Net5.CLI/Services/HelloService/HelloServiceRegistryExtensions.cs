using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.Net5.CLI.Services.HelloService
{
    internal static class HelloServiceRegistryExtensions
    {
        internal static IServiceCollection AddHelloServiceCore(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddSingleton<IHelloService, HelloService>();

            return serviceCollection;
        }

        internal static IServiceCollection AddHelloServicePorts(this IServiceCollection serviceCollection)
        {
            return serviceCollection;
        }
    }
}
