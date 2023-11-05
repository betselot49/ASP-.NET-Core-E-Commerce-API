using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePersistence.Configurations.Entities;

public class ProductConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        // builder.HasKey(p => p.ProductId); => if the primary key was named ProductId, you would have told entity framework to take it as PK
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(p => p.Description) 
            .HasMaxLength(255);

        builder.Property(p => p.Price)
            .IsRequired();

        builder.Property(p => p.StockQuantity)
             .IsRequired();

        builder.Property(p => p.Images)
              .HasMaxLength(1000);

        builder.HasMany(p => p.ProductCategories)
               .WithOne(pc => pc.Product)
               .HasForeignKey(pc => pc.ProductId);

        builder.HasMany(p => p.OrderItems)
             .WithOne(oi => oi.Product)
             .HasForeignKey(oi => oi.ProductId);

        builder.HasMany(p => p.Reviews)
              .WithOne(r => r.Product)
              .HasForeignKey(r => r.ProductId);

        builder.HasIndex(p => p.Name);
    }
}
