using Microsoft.ApplicationInsights.Extensibility;
using Serilog;
using Serilog.Events;
using System.Threading.Tasks;

namespace SeriLog.Net5.CLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var log = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.ApplicationInsights(new TelemetryConfiguration { InstrumentationKey = "ff75007e-f994-43e2-918f-971fa6afbe03"}, TelemetryConverter.Traces)
                .WriteTo.Console()
                .CreateLogger();

            var counter = 1;
            do
            {
                log.Information("Hello world loop {counter}", counter);
                counter++;

                await Task.Delay(2500);
            }while (true);
            
        }
    }
}
