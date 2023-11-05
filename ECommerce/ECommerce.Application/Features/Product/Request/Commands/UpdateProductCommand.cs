using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Product.Request.Commands;

public class UpdateProductCommand : IRequest<BaseCommandResponse>
{
    public ProductsDto ProductsDto { get; set; }   

}
