using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTLab2.Domain.Entities;

namespace PTLab2.Infrastructure.Database.Configuration;

public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
{
    public void Configure(EntityTypeBuilder<PromoCode> builder)
    {
        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Code)
            .HasMaxLength(32);
        
        builder
            .HasIndex(x => x.Discount)
            .IsUnique();

        builder
            .HasData(new []
            {
                new PromoCode { Id = 1, Code = "5sale", Discount = 5 },
                new PromoCode { Id = 2, Code =  "10sale", Discount = 10 },
                new PromoCode { Id = 3, Code =  "15sale", Discount = 15 }
            });
    }
}