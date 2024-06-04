using SeleniumCsharpSpecflow.Pages;
using SeleniumCsharpSpecflow.Config;
using SeleniumCsharpSpecflow.Driver;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumCsharpSpecflow.Support;

namespace SeleniumCsharpSpecflow
{
    internal class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices() 
        {
            var services = new ServiceCollection();

            services
               .AddSingleton(ConfigReader.ReadConfig())
               .AddScoped<IDriverFixture, DriverFixture>()
               .AddScoped<IDriverWait, DriverWait>()
               .AddScoped<IHomePage, HomePage>()
               .AddScoped<ILoginPage, LoginPage>()
               .AddScoped<ISignUpPage, SignUpPage>()
               .AddScoped<IGeneralPage, GeneralPage>()
               .AddScoped<IJsonHelper, JsonHelper>();

            return services;
        }
    }
}
