using PTLab2.Domain.Entities.Base;

namespace PTLab2.Domain.Entities;

public class PromoCode : Entity
{
    public string Code {get;set;} = null!;
    public int Discount {get;set;}
}