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
    public class ProductRatingConfiguration : IEntityTypeConfiguration<ProductRating>
    {
        public void Configure(EntityTypeBuilder<ProductRating> builder)
        {
            builder.HasKey(pr => pr.Id);

            builder.Property(pr => pr.ProductId)
                   .IsRequired();

            builder.Property(pr => pr.AverageRating)
                   .HasColumnType("decimal(18, 2)"); // Adjust the precision and scale as needed;

        }
    }
}
