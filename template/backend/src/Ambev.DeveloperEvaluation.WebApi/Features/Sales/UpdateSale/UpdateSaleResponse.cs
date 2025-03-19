using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// API response model for UpdateSale operation
/// </summary>
public class UpdateSaleResponse
{
    /// <summary>
    /// The unique identifier of the Updated Sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Sale's date
    /// </summary>
    public DateTime SaleDate { get; set; }
    
    /// <summary>
    /// The Sale's Customer
    /// </summary>
    public Customer Customer { get; set; } = null!;

    /// <summary>
    /// The Sale's Branch
    /// </summary>
    public Branch Branch { get; set; } = null!;

    /// <summary>
    /// The Sale's Items
    /// </summary>
    public List<SaleItem> Items { get; set; } = [];

    /// <summary>
    /// The Sale's total amount
    /// </summary>
    public decimal TotalAmount { get; set; } = 0;

    /// <summary>
    /// The Sale's cancellation status
    /// </summary>
    public bool IsCancelled { get; private set; } = false;
}
