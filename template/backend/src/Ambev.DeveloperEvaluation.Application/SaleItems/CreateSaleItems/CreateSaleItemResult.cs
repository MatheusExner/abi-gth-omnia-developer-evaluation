using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSaleItems;

/// <summary>
/// Represents the response returned after successfully creating a new Sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleItemResult
{
    public Guid Id { get; set; }
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
}
