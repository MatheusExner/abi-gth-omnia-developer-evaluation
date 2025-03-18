using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

/// <summary>
/// API response model for GetProduct operation
/// </summary>
public class GetProductResponse
{
    /// <summary>
    /// The unique identifier of the Product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Product's name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The Product's Price
    /// </summary>
    public decimal Price { get; set; }
}
