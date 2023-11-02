using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Features.Product.Request.Commands;
using ECommerce.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductController (IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateProductDto product)
    {
        var command = new CreateProductCommand { ProductDto = product };
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}
