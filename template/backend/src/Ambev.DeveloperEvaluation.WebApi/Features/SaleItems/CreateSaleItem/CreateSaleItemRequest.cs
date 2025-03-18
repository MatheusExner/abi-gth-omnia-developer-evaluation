using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// Represents a request to create a new SaleItem in the system.
/// </summary>
public class CreateSaleItemRequest
{
    /// <summary>
    /// The ID of the product associated with the SaleItem.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }
}