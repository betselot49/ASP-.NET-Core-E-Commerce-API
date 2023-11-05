using ECommerce.Domain;
using ECommerce.Identity.Configuration;
using ECommerce.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePersistence;

public class ECommerceDbContext : AuditableDbContext
{
    public ECommerceDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure the value converter for the Images property
        var imagesConverter = new ValueConverter<List<string>, string>(
            v => string.Join(";", v),   // Convert List<string> to string
            v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToList()  // Convert string to List<string>
        );

        modelBuilder.Entity<Products>()
            .Property(p => p.Images)
            .HasConversion(imagesConverter);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ECommerceDbContext).Assembly);
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
    }

    //public DbSet<Users> Users { get; set; }
    public DbSet<Categories> Category { get; set; }
    public DbSet<OrderItem> OrederItem { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<PaymentMethods> PaymentMethods { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<ProductRating> ProductRating { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<ShippingMethods> ShippingMethods { get; set; }


}

