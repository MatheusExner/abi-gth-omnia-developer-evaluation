using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItems;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems;

/// <summary>
/// Controller for managing SaleItem operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SaleItemsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SaleItemsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SaleItemsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new SaleItems
    /// </summary>
    /// <param name="request">The SaleItem creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created SaleItem details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleItemResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSaleItem([FromBody] CreateSaleItemRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleItemRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSaleItemCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSaleItemResponse>
        {
            Success = true,
            Message = "SaleItem created successfully",
            Data = _mapper.Map<CreateSaleItemResponse>(response)
        });
    }

}
