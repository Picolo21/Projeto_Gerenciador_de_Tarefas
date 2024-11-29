using TaskFlow.Application.Interfaces.v1;
using TaskFlow.Application.Mappings.v1;
using TaskFlow.Infrastructure.Data.v1;
using TaskFlow.Infrastructure.Repositories.v1;

namespace TaskFlow.Api.Infrastructure.IoC;

public static class Bootstrapper
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddSingleton<MongoDbContext>(sp =>
            new MongoDbContext(
                configuration.GetConnectionString("MongoDB"),
                configuration["DatabaseName"]
            )
        );

        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IWorkRepository, WorkRepository>();

        services.AddAutoMapper(typeof(DtoToDomainMappingProfile));

        return services;
    }
}
