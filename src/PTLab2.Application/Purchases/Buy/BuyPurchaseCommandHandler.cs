using MediatR;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Application.Purchases.Buy;

public class BuyPurchaseCommandHandler : IRequestHandler<BuyPurchaseCommand>
{
    private readonly IPurchaseRepository _purchaseRepository;

    public BuyPurchaseCommandHandler(
        IPurchaseRepository purchaseRepository)
    {
        _purchaseRepository = purchaseRepository;
    }

    public async Task Handle(BuyPurchaseCommand request, CancellationToken cancellationToken)
    {
        var purchase = new Purchase 
        { 
            ProductId = request.ProductId,
            Person = request.Person,
            Address = request.Address,
            Date = DateTime.UtcNow
        };
        await _purchaseRepository.AddPurchaseAsync(purchase);
    }
}