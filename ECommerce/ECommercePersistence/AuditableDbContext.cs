using ECommerce.Domain.Common;
using ECommerce.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePersistence;

public class AuditableDbContext : IdentityDbContext<ApplicationUser>
{
    public AuditableDbContext(DbContextOptions options) : base(options) { }

    public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
    {
        foreach (var entity in base.ChangeTracker.Entries<BaseDomainEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))

        {
            Console.WriteLine($" ============>  usernmae => {username}");
            entity.Entity.LastModifiedDate = DateTime.Now;
            entity.Entity.LastModifiedBy = username;

            if (entity.State == EntityState.Added)
            {
                entity.Entity.DateCreated = DateTime.Now;
                entity.Entity.CreatedBy = username;
            }
        }
        var result = await base.SaveChangesAsync(); 
        return result;

    }
}
