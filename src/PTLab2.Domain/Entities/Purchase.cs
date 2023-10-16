using PTLab2.Domain.Entities.Base;

namespace PTLab2.Domain.Entities;

public class Purchase : Entity
{
    public int ProductId {get;set;}
    public string Person {get;set;} = string.Empty;
    public string Address {get;set;} = string.Empty;
    public DateTime Date {get;set;}
}