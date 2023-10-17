using FluentAssertions;
using NSubstitute;
using PTLab2.Application.Promocodes.GetByCode;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Tests.PromoCodes;
public class GetPromoCodeBeCodeCommandHandlerTest
{
    private readonly IPromoCodeRepository _promoCodeRepository;

    public GetPromoCodeBeCodeCommandHandlerTest()
    {
        _promoCodeRepository = Substitute.For<IPromoCodeRepository>();
    }

    [Fact]
    public async Task Handle_PromoCodeExists_ReturnsPromoCode()
    {
        // Arrange
        var handler = new GetPromoCodeByCodeCommandHandler(_promoCodeRepository);

        var request = new GetPromoCodeByCodeCommand("PROMO123");

        var expectedPromoCode = new PromoCode { Code = "PROMO123", Discount = 1 };

        _promoCodeRepository.GetByCodeAsync(request.Code).Returns(expectedPromoCode);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(expectedPromoCode);
    }

    [Fact]
    public async Task Handle_PromoCodeNotFound_ThrowsException()
    {
        // Arrange
        var handler = new GetPromoCodeByCodeCommandHandler(_promoCodeRepository);

        var request = new GetPromoCodeByCodeCommand("PROMO456");

        _promoCodeRepository.GetByCodeAsync(request.Code).Returns((PromoCode)null);

        // Act
        Func<Task> act = async() => await handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<Exception>();
    }
}
