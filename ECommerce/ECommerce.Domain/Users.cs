using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain;

public class Users : BaseDomainEntity
{
    public Users()
    {
        Orders = new HashSet<Orders>();
        PaymentMethods = new HashSet<PaymentMethods>();
        Reviews = new HashSet<Reviews>();
    }

    [Required]
    public string? Username { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }

    [Required]
    public string? Role { get; set; }

    // Navigation Properties
    public virtual ICollection<Orders>? Orders { get; set; }
    public virtual ICollection<PaymentMethods>? PaymentMethods { get; set; }
    public virtual ICollection<Reviews>? Reviews { get; set; }
}
