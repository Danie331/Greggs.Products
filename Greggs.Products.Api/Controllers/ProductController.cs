using AutoMapper;
using Greggs.Products.Api.CQRS.Query.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using ApiDto = Greggs.Products.Api.Models;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IMediator mediator, IMapper mapper)
    {
        _logger = logger;
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// User Story 1: Return products ordered by date in descending order
    /// </summary>
    [HttpGet("GetProductsSortedByDate"), Produces(typeof(ApiDto.PaginatedList<ApiDto.Product>))]
    public async Task<IActionResult> GetProductsSortedByDate(int? pageStart, int? pageSize)
    {
        var data = await _mediator.Send(new GetProductsSortedByDateQuery(pageStart, pageSize));
        var response = _mapper.Map<ApiDto.PaginatedList<ApiDto.Product>>(data);
        return Ok(response);
    }

    [HttpGet("GetRandomProducts"), Produces(typeof(ApiDto.PaginatedList<ApiDto.Product>))]
    public async Task<IActionResult> GetRandomProducts(int pageStart = 0, int pageSize = 5)
    {
        var data = await _mediator.Send(new GetRandomSelectionQuery(pageStart, pageSize));
        var response = _mapper.Map<ApiDto.PaginatedList<ApiDto.Product>>(data);
        return Ok(response);
    }
}