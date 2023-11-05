using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Product.Request.Commands;

public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }
}
