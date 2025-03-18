using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// API response model for GetProducts operation
/// </summary>
public class GetProductsResponse
{
    public List<GetProductsResponse> Data { get; set; } = [];
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
