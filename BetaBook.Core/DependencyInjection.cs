using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using BetaBook.Core.Data;

namespace BetaBook.Core;

public static class DependencyInjection {
    public static IServiceCollection AddEntityManagement(this IServiceCollection services) {
        services.AddSingleton<DbManager>();

        return services;
    }
}
