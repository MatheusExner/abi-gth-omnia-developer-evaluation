using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Represents a request to Update a new Sale in the system.
/// </summary>
public class UpdateSaleRequest
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