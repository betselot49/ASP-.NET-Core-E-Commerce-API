using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain;

public class Products : BaseDomainEntity
{
    public Products () 
    {
        ProductCategories = new HashSet<ProductCategory>();
        OrderItems = new HashSet<OrderItem>();
        Reviews = new HashSet<Reviews>();

    }

    [Required]
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }
    public List<string>? Images { get; set; }
    public int CategoryId { get; set; }

    // Navigation Property
    public virtual Categories? Category { get; set; }  
    public virtual ICollection<ProductCategory> ProductCategories { get;}
    public virtual ICollection<OrderItem> OrderItems { get; set; }
    public virtual ICollection<Reviews> Reviews { get; set; }
}
