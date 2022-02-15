using AOPExample.Core.Factories;
using AOPExample.Core.Repositories;
using AOPExample.Core.Services;
using AOPExample.Core.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace AOPExample.Core.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection service)
        {
            service.AddTransient<ICountryService, CountryService>();
        }

        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddTransient<ICountryRepository, CountryRepository>();
            
            if (ProjectConstant.UseDecorator)
            {
                service.Decorate<ICountryRepository,DecoCountryRepository>();
            }
                
        }

        public static void AddFactories(this IServiceCollection service)
        {
            service.AddTransient<ValidatorBase, GameValidator>();
            service.AddTransient<ValidatorBase, SportValidator>();
            service.AddSingleton<IValidatorFactory, ValidatorFactory>();
        }

    }
}