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
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethods>
    {
        public void Configure(EntityTypeBuilder<PaymentMethods> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.UserId)
                   .IsRequired();

            builder.Property(pm => pm.PaymentMethodName)
                   .IsRequired()
                   .HasMaxLength(255); // Adjust the maximum length as needed

            builder.Property(pm => pm.PaymentMethodType)
                   .HasMaxLength(100); // Adjust the maximum length as needed

            builder.Property(pm => pm.PaymentMethodDetails)
                   .HasMaxLength(500); // Adjust the maximum length as needed

            builder.HasOne(pm => pm.User)
                   .WithMany(u => u.PaymentMethods)
                   .HasForeignKey(pm => pm.UserId);
        }
    }
}
