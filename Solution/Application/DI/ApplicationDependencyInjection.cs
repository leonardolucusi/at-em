using Application.ResponseUtility;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DI
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection(this  IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ValidationResult>();
            return services;
        }
    }
}
