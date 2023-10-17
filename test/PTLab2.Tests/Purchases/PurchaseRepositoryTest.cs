using FluentAssertions;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;
using PTLab2.Infrastructure.Database.Repositories;
using PTLab2.Tests.Common;

namespace PTLab2.Tests.Purchases;
public class PurchaseRepositoryTest : TestBase
{
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseRepositoryTest()
    {
        _purchaseRepository = new PurchaseRepository(ShopDbContext);

    }

    [Fact]
    public async Task Add_CorrectInput_Success()
    {
        // Arrange
        var purchaseToCreate = new Purchase
        {
            Id = 10,
            Person = "Test Purchase",
            Address = "Test Address",
            ProductId = ShopDbContextFactory.ProductId1
        };

        // Act
        Func<Task> act = async () => await _purchaseRepository.AddPurchaseAsync(purchaseToCreate);

        // Assert

        await act.Should().NotThrowAsync<Exception>();
    }

    [Fact]
    public async Task Add_InvalidKeyInput_ThrowsException()
    {
        // Arrange
        var purchaseToCreate = new Purchase
        {
            Id = ShopDbContextFactory.PurchaseId1, // duplicate key
            Person = "Test Purchase",
            Address = "Test Address"
        };

        // Act
        Func<Task> act = async () => await _purchaseRepository.AddPurchaseAsync(purchaseToCreate);

        // Assert

        await act.Should().ThrowAsync<Exception>();
    }
}