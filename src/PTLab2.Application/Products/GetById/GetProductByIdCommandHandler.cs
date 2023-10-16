using MediatR;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Application.Products.GetById;

public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdCommand, Product>
{
    private readonly IProductRepository _productRepository;

    public GetProductByIdCommandHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Product> Handle(
        GetProductByIdCommand request, 
        CancellationToken cancellationToken)
    {
        var product = 
            await _productRepository.GetProductByIdAsync(request.Id) ?? 
            throw new Exception("Product not found");
        return product;
    }
}