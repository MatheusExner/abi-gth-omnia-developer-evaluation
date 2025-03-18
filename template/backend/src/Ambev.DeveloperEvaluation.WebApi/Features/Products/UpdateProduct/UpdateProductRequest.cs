using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

/// <summary>
/// Represents a request to create a new Product in the system.
/// </summary>
public class UpdateProductRequest
{
    /// <summary>
    /// Gets or sets the Productname. Must be unique and contain only valid characters.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ProductPrice. Must be bigger then zero.
    /// </summary>
    public decimal Price { get; set; } 
}