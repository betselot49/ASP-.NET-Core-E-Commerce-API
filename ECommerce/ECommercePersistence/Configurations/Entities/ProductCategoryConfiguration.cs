using ECommerce.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePersistence.Configurations.Entities
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(pc => pc.Id);

            builder.Property(pc => pc.ProductId)
                   .IsRequired();

            builder.Property(pc => pc.CategoryId)
                   .IsRequired();

            builder.HasOne(pc => pc.Product)
                   .WithMany(p => p.ProductCategories)
                   .HasForeignKey(pc => pc.ProductId);

            builder.HasOne(pc => pc.Category)
                   .WithMany(c => c.ProductCategories)
                   .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
