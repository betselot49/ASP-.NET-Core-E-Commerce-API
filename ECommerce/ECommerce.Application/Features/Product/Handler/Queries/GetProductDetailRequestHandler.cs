using AutoMapper;
using ECommerce.Application.Contracts.Persistency;
using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Features.Product.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Product.Handler.Queries
{
    public class GetProductDetailRequestHandler : IRequestHandler<GetProductDetailRequest, ProductsDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepositiry _productRepositiry;

        public GetProductDetailRequestHandler(IMapper mapper, IProductRepositiry productRepositiry)
        {
            _mapper = mapper;
            _productRepositiry = productRepositiry;
        }

        public async Task<ProductsDto> Handle(GetProductDetailRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepositiry.Get(request.Id);
            if (product == null) throw new NotFoundException(nameof(product), request.Id);
            
            return  _mapper.Map<ProductsDto>(product);
        }
    }
}
