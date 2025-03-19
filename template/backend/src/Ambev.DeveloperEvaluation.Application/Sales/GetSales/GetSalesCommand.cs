using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

/// <summary>
/// Command for retrieving a list of Sales
/// </summary>
public record GetSalesCommand : IRequest<IQueryable<Sale>>
{

}
