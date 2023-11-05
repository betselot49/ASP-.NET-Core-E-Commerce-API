using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain;

public class Orders : BaseDomainEntity
{
    public Orders() 
    {
        OrderItems = new HashSet<OrderItem>();
    }


    public int UserId { get; set; } 
    public DateTime OrderDate { get; set; }

    [Required]
    public string? ShippingAddress { get; set; }

    public decimal TotalPrice { get; set; }
    public string? ShippingStatus { get; set; }
    public string? OrderStatus { get; set; }
    public string? PaymentStatus { get; set; }

    // Navigation properties
    public virtual ICollection<OrderItem>? OrderItems { get; set; }
}
