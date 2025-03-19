using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Handler for processing GetSalesCommand requests
/// </summary>
public class GetSalesHandler : IRequestHandler<GetSalesCommand, IQueryable<Sale>>
{
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    /// Initializes a new instance of GetSalesHandler
    /// </summary>
    /// <param name="salesRepository">The Sales repository</param>
    public GetSalesHandler(
        ISaleRepository salesRepository)
    {
        _saleRepository = salesRepository;
    }

    /// <summary>
    /// Handles the GetSalesCommand request
    /// </summary>
    /// <param name="request">The GetSales command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Sales details if found</returns>
    public async Task<IQueryable<Sale>> Handle(GetSalesCommand request, CancellationToken cancellationToken)
    {
        return (IQueryable<Sale>)_saleRepository.GetAllQueryable();
    }
}
