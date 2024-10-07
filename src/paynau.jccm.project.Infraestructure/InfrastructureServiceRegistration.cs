using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using paynau.jccm.project.Application.Contracts.Persistence;
using paynau.jccm.project.Infraestructure.Repositories;

namespace paynau.jccm.project.Infraestructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

        services.AddScoped<IPersonRepository, PersonRepository>();

        return services;
    }

}
