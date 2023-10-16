using Microsoft.EntityFrameworkCore;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Infrastructure.Database.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopDbContext _dbContext;

    public ProductRepository(
        ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _dbContext.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _dbContext.Products.ToListAsync();
    }
}