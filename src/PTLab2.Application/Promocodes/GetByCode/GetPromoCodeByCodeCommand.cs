using MediatR;
using PTLab2.Domain.Entities;

namespace PTLab2.Application.Promocodes.GetByCode;

public record GetPromoCodeByCodeCommand(string Code) : IRequest<PromoCode>;