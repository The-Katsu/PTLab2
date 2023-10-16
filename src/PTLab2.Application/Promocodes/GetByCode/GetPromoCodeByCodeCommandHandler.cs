using MediatR;
using PTLab2.Domain.Entities;
using PTLab2.Domain.Interfaces.Repositories;

namespace PTLab2.Application.Promocodes.GetByCode;

public class GetPromoCodeByCodeCommandHandler : IRequestHandler<GetPromoCodeByCodeCommand, PromoCode>
{
    private readonly IPromoCodeRepository _promoCodeRepository;

    public GetPromoCodeByCodeCommandHandler(
        IPromoCodeRepository promoCodeRepository)
    {
        _promoCodeRepository = promoCodeRepository;
    }

    public async Task<PromoCode> Handle(
        GetPromoCodeByCodeCommand request, 
        CancellationToken cancellationToken)
    {
        var promoCode = await _promoCodeRepository.GetByCodeAsync(request.Code);
        
        if (promoCode is null) throw new Exception("PromoCode not found");

        return promoCode;
    }
}