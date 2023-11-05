using ECommerce.Application.DTOs.Category;
using ECommerce.Application.Features.Category.Request.Commands;
using ECommerce.Application.Features.Category.Request.Queries;
using ECommerce.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CategoryController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
        _mediator = mediator;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet]
    public async Task<ActionResult<CategoryDto>> GetAll()
    {
        var categories = await _mediator.Send(new GetCategoryListRequest());
        return Ok(categories);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> Get(int id)
    {
        var category = await _mediator.Send(new GetCategoryDetailRequest { Id = id });
        return Ok(category);
    }


    [HttpPost]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateCategoryDto category)
    {
        var response = await _mediator.Send(new CreateCategoryCommand { CategoryDto = category });
        return Ok(response);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<BaseCommandResponse>> Put([FromBody] CategoryDto category)
    {
        var response = await _mediator.Send(new UpdateCategoryCommand { Category = category });
        return Ok(response);
    }

    //[HttpDelete("{id}")]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesDefaultResponseType]
    //public async Task<ActionResult> Delete(int id)
    //{
    //    await _mediator.Send(new DeleteCategoryCommand { Id = id });
    //    return NoContent();
    //}

}
