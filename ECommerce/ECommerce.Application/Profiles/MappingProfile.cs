using AutoMapper;
using ECommerce.Application.DTOs.Category;
using ECommerce.Application.DTOs.Product;
using ECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            #region Product Mapping
            CreateMap<Products, ProductsDto>().ReverseMap();
            CreateMap<Products, CreateProductDto>().ReverseMap();
            #endregion Product

            #region Category Mapping
            CreateMap<Categories, CategoryDto>().ReverseMap();
            CreateMap<Categories, CreateCategoryDto>().ReverseMap();
            #endregion Category
        }
    }
}
