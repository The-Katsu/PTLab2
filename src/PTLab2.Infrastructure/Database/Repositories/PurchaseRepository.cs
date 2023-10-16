using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Infrastructure.Database.Repositories;

public class PurchaseRepository : IPurchaseRepository
{
    private readonly ShopDbContext _dbContext;

    public PurchaseRepository(
        ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPurchaseAsync(Purchase purchase)
    {
        await _dbContext.AddAsync(purchase);
        await _dbContext.SaveChangesAsync();
    }
}