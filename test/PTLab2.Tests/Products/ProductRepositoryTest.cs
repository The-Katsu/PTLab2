using FluentAssertions;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;
using PTLab2.Infrastructure.Database.Repositories;
using PTLab2.Tests.Common;

namespace PTLab2.Tests.Products;
public class ProductRepositoryTest : TestBase
{
    private readonly IProductRepository _productRepository;

    public ProductRepositoryTest()
    {
        _productRepository = new ProductRepository(ShopDbContext);
    }

    [Fact]
    public async Task Get_ReturnsListOfPRoducts()
    {
        // Act
        var products = await _productRepository.GetProductsAsync();

        //Assert
        products.Should().HaveCount(3);
        products.Should().AllBeOfType<Product>();
        products.Should().BeOfType<List<Product>>();
    }

    [Fact]
    public async Task Get_CorrectInput_ReturnProduct()
    {
        // Act
        var product = await _productRepository.GetProductByIdAsync(ShopDbContextFactory.ProductId1);

        // Assert
        product.Should().NotBeNull();
        product.Should().BeOfType<Product>();
        product!.Id.Should().Be(ShopDbContextFactory.ProductId1);
    }

    [Fact]
    public async Task Get_InvalidInput_ReturnNull()
    {
        // Act
        var product = await _productRepository.GetProductByIdAsync(123);

        // Assert
        product.Should().BeNull();
    }
}
