using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Features.Product.Request.Commands;
using ECommerce.Application.Features.Product.Request.Queries;
using ECommerce.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductController (IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductsDto>>> Get()
    {
        var products = await _mediator.Send(new GetProductListRequest());
        return Ok(products);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ProductsDto>> Get(int id)
    {
        var product = await _mediator.Send(new GetProductDetailRequest { Id = id});
        return Ok(product);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductDto product)
    {
        var command = new CreateProductCommand { ProductDto = product };
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<BaseCommandResponse>> Put([FromBody]ProductsDto productsDto)
    {
        var command = new UpdateProductCommand {ProductsDto = productsDto };
        var response = await _mediator.Send(command);
        return Ok(response);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteProductCommand { Id = id};
        await _mediator.Send(command);
        return NoContent();
    }
}
