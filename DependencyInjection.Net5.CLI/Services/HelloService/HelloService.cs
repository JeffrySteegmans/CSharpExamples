using System;

namespace DependencyInjection.Net5.CLI.Services.HelloService
{
    internal class HelloService : IHelloService
    {
        public void WriteMessage()
        {
            Console.WriteLine("Hello World");
        }
    }
}
