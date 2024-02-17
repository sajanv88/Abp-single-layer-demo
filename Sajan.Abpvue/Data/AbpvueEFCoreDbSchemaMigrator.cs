using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace Sajan.Abpvue.Data;

public class AbpvueEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public AbpvueEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AbpvueDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpvueDbContext>()
            .Database
            .MigrateAsync();
    }
}
