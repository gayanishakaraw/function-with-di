using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TestFunction.Models;

namespace TestFunction.Services
{
    public class Service : IService
    {
        private AppConfiguration _appConfig;
        private ILogger<Service> _logger;

        public Service(ILogger<Service> logger, IOptions<AppConfiguration> appConfig)
        {
            _appConfig = appConfig.Value;
            _logger = logger;
        }

        public double CalculateSum(double one, double two)
        {
            _logger.LogTrace($"This is the configuration {_appConfig.DatabaseName} and {_appConfig.ContainerName}");
            _logger.LogInformation($"calculating value {one} and {two}");
            return one + two;
        }
    }
}
