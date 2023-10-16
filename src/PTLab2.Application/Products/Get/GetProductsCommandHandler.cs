using MediatR;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Application.Products.Get;

public class GetProductsCommandHandler : IRequestHandler<GetProductsCommand, IEnumerable<Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsCommandHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> Handle(
        GetProductsCommand request, 
        CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsAsync();
        return products;
    }
}