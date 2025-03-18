using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleItems.CreateSaleItem;

/// <summary>
/// API response model for CreateSaleItem operation
/// </summary>
public class CreateSaleItemResponse
{
    /// <summary>
    /// The Id of the SaleItem
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Id of the Product
    /// </summary>
    public Product Product { get; set; } = null!;

    /// <summary>
    /// The quantity of the SaleItem
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the SaleItem
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The discount of the SaleItem
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// The total price of the SaleItem
    /// </summary>
    public decimal TotalPrice { get; set; }
}
