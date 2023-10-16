using Microsoft.EntityFrameworkCore;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Infrastructure.Database.Repositories;

public class PromoCodeRepository : IPromoCodeRepository
{
    private readonly ShopDbContext _shopDbContext;

    public PromoCodeRepository(
        ShopDbContext shopDbContext)
    {
        _shopDbContext = shopDbContext;
    }

    public async Task<PromoCode?> GetByCodeAsync(string code)
    {
        return await _shopDbContext.PromoCodes.FirstOrDefaultAsync(x => string.Equals(x.Code, code));
    }
}