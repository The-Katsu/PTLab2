using PTLab2.Domain.Entities;

namespace PTLab2.Domain.Interfaces.Repositories;

public interface IPurchaseRepository
{
    public Task AddPurchaseAsync(Purchase purchase);
}