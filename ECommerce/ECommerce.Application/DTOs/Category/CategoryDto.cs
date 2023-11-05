using ECommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Category
{
    public class CategoryDto : BaseDto, ICategoryDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
