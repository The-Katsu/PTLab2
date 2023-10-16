using PTLab2.Domain.Entities;

namespace PTLab2.Domain.Interfaces.Repositories;

public interface IProductRepository 
{
    public Task<IEnumerable<Product>> GetProductsAsync();
}