using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain;

public class PaymentMethods : BaseDomainEntity
{
    public int UserId { get; set; }

    [Required]
    public string? PaymentMethodName { get; set; }

    public string? PaymentMethodType { get; set; }
    public string? PaymentMethodDetails { get; set; }

    // Navigation properties
    public virtual Users? User { get; set; }
}
