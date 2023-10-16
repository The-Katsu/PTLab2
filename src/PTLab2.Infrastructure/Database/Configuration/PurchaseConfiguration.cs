using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTLab2.Domain.Entities;

namespace PTLab2.Infrastructure.Database.Configuration;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Person)
            .HasMaxLength(255);

        builder
            .Property(x => x.Address)
            .HasMaxLength(255);

        builder
            .HasOne<Product>()
            .WithMany(x => x.Purchases)
            .HasForeignKey(x => x.ProductId)
            .IsRequired();
    }
}