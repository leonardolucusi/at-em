using Application.Command;
using Application.Command.Interface;
using Application.Query;
using Application.Query.Interface;
using Application.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DI
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ValidationResult>();
            
            services.AddScoped<IProductCommandHandler, ProductCommandCommandHandler>();
            
            services.AddScoped<IProductQueryHandler, ProductQueryHandler>();
            
            return services;
        }
    }
}
