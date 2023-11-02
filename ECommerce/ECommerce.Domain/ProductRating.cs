using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain;

public class ProductRating : BaseDomainEntity
{
    public int ProductId { get; set; }
    public decimal AverageRating { get; set; }

    // Navigation properties
    public virtual Products? Product { get; set; }

}
