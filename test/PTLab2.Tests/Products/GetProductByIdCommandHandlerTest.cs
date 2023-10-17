using FluentAssertions;
using NSubstitute;
using PTLab2.Application.Products.GetById;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;
using PTLab2.Tests.Common;

namespace PTLab2.Tests.Products;
public class GetProductByIdCommandHandlerTest
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdCommandHandlerTest()
    {
        _productRepository = Substitute.For<IProductRepository>();
    }

    [Fact]
    public async Task Handle_ProductExists_ReturnsProduct()
    {
        // Arrange
        var handler = new GetProductByIdCommandHandler(_productRepository);

        var request = new GetProductByIdCommand(ShopDbContextFactory.ProductId1);

        var expectedProduct = new Product { Id = 1, Name = "Product 1" };

        _productRepository.GetProductByIdAsync(request.Id).Returns(expectedProduct);

        // Act
        var result = await handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(expectedProduct);
    }

    [Fact]
    public async Task Handle_ProductNotFound_ThrowsException()
    {
        // Arrange
        var handler = new GetProductByIdCommandHandler(_productRepository);

        var request = new GetProductByIdCommand(ShopDbContextFactory.ProductId1);

        _productRepository.GetProductByIdAsync(request.Id).Returns((Product)null);

        // Act 
        Func<Task> act = async () => await handler.Handle(request, CancellationToken.None);

        // Act and Assert
        await act.Should().ThrowAsync<Exception>();
    }
}