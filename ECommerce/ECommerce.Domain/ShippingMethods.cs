using ECommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain;

public class ShippingMethods : BaseDomainEntity
{
    public string? ShippingMethodName { get; set; }
    public string? ShippingMethodType { get; set; }
    public decimal ShippingPrice { get; set; }
}
