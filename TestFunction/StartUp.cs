using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TestFunction.Models;
using TestFunction.Services;

[assembly: FunctionsStartup(typeof(TestFunction.Startup))]
namespace TestFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Registering Configurations (IOptions pattern)
            builder
                .Services
                .AddOptions<AppConfiguration>()
                .Configure<IConfiguration>((appConfigurations, configuration) =>
                {
                    configuration
                    .GetSection("AppSettings")
                    .Bind(appConfigurations);
                });

            // Registering Serilog provider
            var logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            builder.Services.AddLogging(lb => lb.AddSerilog(logger));

            // Registering services
            builder
                .Services
                .AddSingleton<IService, Service>();
        }
    }
}
