using DeZon.Orders.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DeZon.Orders.Extensions;

public static class ApplicationBuilderExtension
{
    public static IApplicationBuilder UseMigrationOfDbContext<T>(this IApplicationBuilder builder) where T : DataContext
    {
        using var scope = builder.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<T>();
        var migrations = context.Database.GetPendingMigrations().ToArray();

        if (!migrations.Any())
        {
            return builder;
        }
        
        context.Database.Migrate();
        
        return builder;
    }
}