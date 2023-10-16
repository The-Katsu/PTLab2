using MediatR;
using PTLab2.Domain.Entities;

namespace PTLab2.Application.Products.Get;

public record GetProductsCommand : IRequest<IEnumerable<Product>>;