using MediatR;
using PTLab2.Domain.Entities;

namespace PTLab2.Application.Products.GetById;

public record GetProductByIdCommand(int Id) : IRequest<Product>;