using FluentAssertions;
using NSubstitute;
using PTLab2.Application.Purchases.Buy;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Tests.Purchases;
public class BuyPurchaseCommandHandlerTest
{
    private readonly IPurchaseRepository _purchaseRepository;

    public BuyPurchaseCommandHandlerTest()
    {
        _purchaseRepository = Substitute.For<IPurchaseRepository>();
    }

    [Fact]
    public async Task Handle_ValidPurchase_AddsPurchaseToRepository()
    {
        // Arrange
        var handler = new BuyPurchaseCommandHandler(_purchaseRepository);

        var request = new BuyPurchaseCommand(
            1,
            "John Doe",
            "123 Main St"
        );

        // Act
        Func<Task> act = async() => await handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().NotThrowAsync<Exception>();
    }
}
