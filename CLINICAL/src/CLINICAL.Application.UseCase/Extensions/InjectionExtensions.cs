
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace CLINICAL.Application.UseCase.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication( this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
