using IntegrationTests.Config;
using IntegrationTests.RestHelpers;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;


namespace IntegrationTests
{
    internal class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices() 
        {
            var services = new ServiceCollection();

            services
               .AddSingleton(ConfigReader.ReadConfig())
               .AddScoped<IRestHelper, RestHelper>();

            return services;
        }
    }
}
