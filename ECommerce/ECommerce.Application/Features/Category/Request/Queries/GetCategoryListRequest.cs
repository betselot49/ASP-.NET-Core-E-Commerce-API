using ECommerce.Application.DTOs.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Category.Request.Queries
{
    public class GetCategoryListRequest : IRequest<List<CategoryDto>>
    {
    }
}
