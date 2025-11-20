using Microsoft.Extensions.DependencyInjection;

namespace Application.DI
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection(this  IServiceCollection services)
        {
            return services;
        }
    }
}
