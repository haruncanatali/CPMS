using System.Reflection;
using CPMS.Application.Common.Interfaces;
using CPMS.Application.Common.Managers;
using CPMS.Application.Common.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace CPMS.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddOptions();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MappingProfile).Assembly));
        services.AddTransient<IFileService, FileManager>();
        return services;
    }
}