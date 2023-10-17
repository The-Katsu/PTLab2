using Microsoft.EntityFrameworkCore;
using PTLab2.Domain.Entities;
using PTLab2.Infrastructure.Database;

namespace PTLab2.Tests.Common;

public class ShopDbContextFactory
{
    public static int ProductId1 = 1;
    public static int ProductId2 = 2;
    public static int ProductId3 = 3;

    public static int PurchaseId1 = 1;
    public static int PurchaseId2 = 2;
    public static int PurchaseId3 = 3;

    public static int PromoCodeId1 = 1;
    public static int PromoCodeId2 = 2;
    public static int PromoCodeId3 = 3;

    public static ShopDbContext Create()
    {
        var opt = new DbContextOptionsBuilder<ShopDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new ShopDbContext(opt);

        context.Database.EnsureCreated();

        context.Purchases.AddRange(
            new Purchase
            {
                Id = PurchaseId1,
                Person = "Test Person 1",
                Address = "Test Address 1",
                ProductId = ProductId1
            },
            new Purchase
            {
                Id = PurchaseId2,
                Person = "Test Person 2",
                Address = "Test Address 2",
                ProductId = ProductId2
            },
            new Purchase
            {
                Id = PurchaseId3,
                Person = "Test Person 3",
                Address = "Test Address 3",
                ProductId = ProductId3
            }
        );
        context.SaveChanges();
        return context;
    }

    public static void Destroy(ShopDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
