using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PTLab2.Domain.Entities;

namespace PTLab2.Infrastructure.Database.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder
            .Property(x => x.Name)
            .HasMaxLength(255);

        builder
            .HasMany(x => x.Purchases)
            .WithOne()
            .HasForeignKey(x => x.ProductId)
            .IsRequired();

        builder.HasData(new[] 
        {
            new Product { Id = 1, Name = "Детская игрушка №1", Price = 2000 },
            new Product { Id = 2, Name = "Детская игрушка №2", Price = 1000 },
            new Product { Id = 3, Name = "Детская игрушка №3", Price = 500 }
        });
    }
}