using ECommerce.Application.DTOs.Category;
using ECommerce.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Category.Request.Commands
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateCategoryDto CategoryDto { get; set; }
    }
}
