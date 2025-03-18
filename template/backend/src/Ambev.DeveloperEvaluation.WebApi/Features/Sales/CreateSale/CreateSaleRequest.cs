using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new Sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// The customer Id of the sale.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// The branch Id of the sale.
    /// </summary>
    public Guid BranchId { get; set; }

    /// <summary>
    /// The sale items Ids of the sale.
    /// </summary>
    public List<Guid> SaleItemsIds { get; set; } = [];
}