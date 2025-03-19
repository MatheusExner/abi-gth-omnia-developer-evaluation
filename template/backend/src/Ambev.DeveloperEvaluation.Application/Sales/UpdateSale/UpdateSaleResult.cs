using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the response returned after successfully creating a new Sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created Sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateSaleResult
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
    /// The date and time when the Sale was created
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
    /// The list of items sold in the Sale
    /// </summary>
    public List<SaleItem> Items { get; set; } = [];

    /// <summary>
    /// The total amount of the Sale
    /// </summary>
    public decimal TotalAmount { get; set; } = 0;

    /// <summary>
    /// Indicates whether the Sale was cancelled
    /// </summary>
    public bool IsCancelled { get; private set; } = false;
}
