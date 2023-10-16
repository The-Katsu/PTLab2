using MediatR;

namespace PTLab2.Application.Purchases.Buy;

public record BuyPurchaseCommand(
    int ProductId,
    string Person,
    string Address
) : IRequest;