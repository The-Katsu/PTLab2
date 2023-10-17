using FluentAssertions;
using NSubstitute;
using PTLab2.Application.Products.Get;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Tests.Products;
public class GetProductsCommandHandlerTest
{
    private readonly IProductRepository _productRepository;

    public GetProductsCommandHandlerTest()
    {
        _productRepository = Substitute.For<IProductRepository>();
    }

    [Fact]
    public async Task Handle_CorrectInput_ReturnListOfProducts()
    {
        // Arrange
        var command = new GetProductsCommand();
        var handler = new GetProductsCommandHandler(_productRepository);
        var products = new List<Product> 
        {
            new() { Id = 1, Name = "Детская игрушка №1", Price = 2000 },
            new() { Id = 2, Name = "Детская игрушка №2", Price = 1000 },
            new() { Id = 3, Name = "Детская игрушка №3", Price = 500 }
        };

        _productRepository.GetProductsAsync().Returns(products);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(products);
        result.Should().BeOfType<List<Product>>();
        result.Should().AllBeOfType<Product>();
    }
}
