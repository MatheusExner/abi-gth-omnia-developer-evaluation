using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity
{
    public int SaleNumber { get; set; } = new Random().Next();
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    public Customer Customer { get; set; } = null!;
    public Branch Branch { get; set; } = null!;
    public List<SaleItem> Items { get; set; } = new();
    public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
    public bool IsCancelled { get; private set; } = false;

    public void CancelSale()
    {
        IsCancelled = true;
    }
}
