using PTLab2.Domain.Entities;

namespace PTLab2.Domain.Interfaces.Repositories;

public interface IPromoCodeRepository
{
    public Task<PromoCode?> GetByCodeAsync(string code);
}