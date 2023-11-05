using AutoMapper;
using ECommerce.Application.Contracts.Persistency;
using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Features.Product.Request.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Product.Handler.Queries;

public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductsDto>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepositiry _productRepositiry;

    public GetProductListRequestHandler(IMapper mapper, IProductRepositiry productRepositiry)
    {
        _mapper = mapper;
        _productRepositiry = productRepositiry;
    }

    public async Task<List<ProductsDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepositiry.GetAll();
        return _mapper.Map<List<ProductsDto>>(products);
    }
}
