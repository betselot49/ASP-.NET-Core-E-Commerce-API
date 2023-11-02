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
    public class ShippingMethodConfiguration : IEntityTypeConfiguration<ShippingMethods>
    {
        public void Configure(EntityTypeBuilder<ShippingMethods> builder)
        {
            builder.HasKey(sm => sm.Id);

            builder.Property(sm => sm.ShippingMethodName)
                   .HasMaxLength(255); // Adjust the maximum length as needed.

            builder.Property(sm => sm.ShippingMethodType)
                   .HasMaxLength(255); // Adjust the maximum length as needed.

            builder.Property(sm => sm.ShippingPrice)
                   .HasColumnType("decimal(18, 2)"); // Adjust the precision and scale as needed.

            builder.HasIndex(sm => sm.ShippingMethodName)
                   .IsUnique();

            builder.HasIndex(sm => sm.ShippingMethodType);
        }
    }
}
