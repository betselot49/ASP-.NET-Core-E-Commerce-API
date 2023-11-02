using ECommerce.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Product
{
    public class ProductsDto : BaseDto, IProductDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public List<string>? Images { get; set; }
        public int CategoryId { get; set; }
    }
}
