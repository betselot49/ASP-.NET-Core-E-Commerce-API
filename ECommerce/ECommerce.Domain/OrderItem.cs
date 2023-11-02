using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain;

public class OrderItem : BaseDomainEntity
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }

    // Navigation properties
    public virtual Orders? Order { get; set; }
    public virtual Products? Product { get; set; }
}