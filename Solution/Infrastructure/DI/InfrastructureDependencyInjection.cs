using Infrastructure.Repository;
using Infrastructure.Repository.Interface;
using Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructureDependencyInjection(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IMeasureRepository, MeasureRepository>();
        
        return services;
    }
}