using PTLab2.Domain.Entities.Base;

namespace PTLab2.Domain.Entities;

public class Product : Entity
{
    public string Name {get;set;} = null!;
    public int Price {get;set;}
    public ICollection<Purchase> Purchases {get;} = new List<Purchase>();
}