using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PTLab2.Domain.Config;
using PTLab2.Domain.Interfaces.Repositories;
using PTLab2.Infrastructure.Database;
using PTLab2.Infrastructure.Database.Repositories;

namespace PTLab2.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var sp = services.BuildServiceProvider();
        var dbConfig = sp.GetRequiredService<IOptions<DatabaseConfig>>().Value;

        services.AddDbContext<ShopDbContext>(opt => opt.UseNpgsql(dbConfig.ConnectionString));

        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IPurchaseRepository, PurchaseRepository>();
        services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();

        return services;
    }
}