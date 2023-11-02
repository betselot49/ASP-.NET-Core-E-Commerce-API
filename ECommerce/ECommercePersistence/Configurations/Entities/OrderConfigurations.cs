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
    public class OrderConfigurations : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.UserId)
                   .IsRequired();

            builder.Property(o => o.OrderDate)
                   .IsRequired();

            builder.Property(o => o.ShippingAddress)
                   .IsRequired()
                   .HasMaxLength(255); // Adjust the maximum length as needed

            builder.Property(o => o.TotalPrice)
                   .IsRequired();

            builder.Property(o => o.ShippingStatus)
                   .HasMaxLength(100); // Adjust the maximum length as needed

            builder.Property(o => o.OrderStatus)
                   .HasMaxLength(100); // Adjust the maximum length as needed

            builder.Property(o => o.PaymentStatus)
                   .HasMaxLength(100); // Adjust the maximum length as needed

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId);

            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId);

            builder.HasIndex(o => o.OrderDate);
        }
    }
}
