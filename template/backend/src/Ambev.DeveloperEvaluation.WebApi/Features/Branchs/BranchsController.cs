using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Branchs.CreateBranch;
using Ambev.DeveloperEvaluation.Application.Branchs.CreateBranch;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branchs;

/// <summary>
/// Controller for managing Branch operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BranchsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of BranchsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public BranchsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new Branchs
    /// </summary>
    /// <param name="request">The Branch creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Branch details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateBranchResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBranch([FromBody] CreateBranchRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateBranchRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateBranchCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateBranchResponse>
        {
            Success = true,
            Message = "Branch created successfully",
            Data = _mapper.Map<CreateBranchResponse>(response)
        });
    }

}
