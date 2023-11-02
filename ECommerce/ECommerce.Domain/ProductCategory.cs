using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain;

public class ProductCategory : BaseDomainEntity
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }

    // Navigation properties
    public virtual Products? Product { get; set; }
    public virtual Category? Category { get; set; }
}
