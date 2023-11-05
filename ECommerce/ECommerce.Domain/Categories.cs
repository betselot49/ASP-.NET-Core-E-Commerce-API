using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain;

public class Categories : BaseDomainEntity
{
    public Categories() 
    {
        Products = new HashSet<Products>();
        ProductCategories = new HashSet<ProductCategory>();
    }


    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }

    // Navigation properties
    public virtual ICollection<Products> Products { get; set; }
    public virtual ICollection<ProductCategory> ProductCategories { get; set; }
}
