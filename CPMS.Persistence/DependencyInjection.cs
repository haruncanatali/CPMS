using CPMS.Application.Common.Interfaces;
using CPMS.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CPMS.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlServer"))
        );
        services.AddTransient<IApplicationContext>(provider => provider.GetService<ApplicationContext>());
        return services;
    }
}