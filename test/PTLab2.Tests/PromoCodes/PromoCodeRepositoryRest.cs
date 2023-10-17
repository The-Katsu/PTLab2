using FluentAssertions;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;
using PTLab2.Infrastructure.Database.Repositories;
using PTLab2.Tests.Common;

namespace PTLab2.Tests.PromoCodes;
public class PromoCodeRepositoryRest : TestBase
{
    private readonly IPromoCodeRepository _promoCodeRepository;

    public PromoCodeRepositoryRest()
    {
        _promoCodeRepository = new PromoCodeRepository(ShopDbContext);
    }

    [Fact]
    public async Task GetByCode_CorrectInput_ReturnsPromoCode()
    {
        // Arrange
        var code = "5sale";

        // Act

        var promoCode = await _promoCodeRepository.GetByCodeAsync(code);

        // Assert
        promoCode.Should().NotBeNull();
        promoCode.Should().BeOfType<PromoCode>();
        promoCode!.Code.Should().Be(code);
    }

    [Fact]
    public async Task GetByCode_InvalidInput_ReturnsNull()
    {
        // Arrange
        var code = "invalid code";

        // Act

        var promoCode = await _promoCodeRepository.GetByCodeAsync(code);

        // Assert
        promoCode.Should().BeNull();
    }
}
