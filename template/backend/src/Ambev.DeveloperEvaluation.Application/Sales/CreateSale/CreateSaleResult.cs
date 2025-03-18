using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the response returned after successfully creating a new Sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleResult
{
    public Guid Id { get; set; }
    public DateTime SaleDate { get; set; } 
    public Customer Customer { get; set; } = null!;
    public Branch Branch { get; set; } = null!;
    public List<SaleItem> Items { get; set; } = [];
    public decimal TotalAmount { get; set; } = 0;
    public bool IsCancelled { get; private set; } = false;
}
