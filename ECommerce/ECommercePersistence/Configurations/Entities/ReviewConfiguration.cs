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
    public class ReviewConfiguration : IEntityTypeConfiguration<Reviews>
    {
        public void Configure(EntityTypeBuilder<Reviews> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.ProductId)
                   .IsRequired();

            builder.Property(r => r.UserId)
                   .IsRequired();

            builder.Property(r => r.Rating)
                   .IsRequired();

            builder.Property(r => r.Comment)
                   .HasMaxLength(500); // Adjust the maximum length as needed.

            builder.Property(r => r.ReviewDate)
                   .IsRequired();

            builder.HasOne(r => r.Product)
                   .WithMany(p => p.Reviews)
                   .HasForeignKey(r => r.ProductId);

            builder.HasOne(r => r.User)
                   .WithMany(u => u.Reviews)
                   .HasForeignKey(r => r.UserId);
        }
    }
}
