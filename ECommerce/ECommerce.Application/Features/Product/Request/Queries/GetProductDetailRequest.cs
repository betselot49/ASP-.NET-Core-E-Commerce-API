using ECommerce.Application.DTOs.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Product.Request.Queries;

public class GetProductDetailRequest : IRequest<ProductsDto>
{
    public int Id { get; set; }
}
