
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The unique identifier of the Sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Sale number
    /// </summary>
    public int SaleNumber { get; set; }

    /// <summary>
    /// The Sale date
    /// </summary> 
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// The Customer who made the Sale
    /// </summary>
    public Customer Customer { get; set; } = null!;
    
    /// <summary>
    /// The Branch where the Sale was made
    /// </summary>
    public Branch Branch { get; set; } = null!;

    /// <summary>
    /// The items in the Sale
    /// </summary>
    public List<SaleItem> Items { get; set; } = new();

    /// <summary>
    /// The total amount of the Sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// indicates if the Sale was cancelled
    /// </summary>
    public bool IsCancelled { get; set; } = false;
}
