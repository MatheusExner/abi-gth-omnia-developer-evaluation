using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem : BaseEntity
{
    public Product Product { get; set; } = null!;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; private set; }
    public decimal TotalPrice => (UnitPrice * Quantity) - Discount;

    public void ApplyDiscount()
    {
        if (Quantity >= 10 && Quantity <= 20)
        {
            Discount = (UnitPrice * Quantity) * 0.2m;
        }
        else if (Quantity >= 4)
        {
            Discount = (UnitPrice * Quantity) * 0.1m;
        }
        else
        {
            Discount = 0;
        }
    }
}
