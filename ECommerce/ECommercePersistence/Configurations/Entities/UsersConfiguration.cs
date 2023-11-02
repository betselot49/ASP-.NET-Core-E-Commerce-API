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
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .HasMaxLength(255) // Adjust the maximum length as needed.
                .IsRequired();

            builder.Property(u => u.Email)
                .HasMaxLength(255) // Adjust the maximum length as needed.
                .IsRequired();

            builder.Property(u => u.Password)
                .HasMaxLength(255) // Adjust the maximum length as needed.
                .IsRequired();

            builder.Property(u => u.Role)
                .HasMaxLength(255) // Adjust the maximum length as needed.
                .IsRequired();

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
