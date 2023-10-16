using Microsoft.EntityFrameworkCore;
using PTLab2.Domain.Entities;
using PTLab2.Infrastructure.Database.Configuration;

namespace PTLab2.Infrastructure.Database;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> opt) : base(opt) { }

    public DbSet<Product> Products {get;set;} = null!;
    public DbSet<Purchase> Purchases {get;set;} = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}