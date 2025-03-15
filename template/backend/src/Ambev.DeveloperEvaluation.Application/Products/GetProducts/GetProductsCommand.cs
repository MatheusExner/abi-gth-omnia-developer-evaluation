using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Command for retrieving a list of Products
/// </summary>
public record GetProductsCommand : IRequest<PaginatedProductResponse>
{
    /// <summary>
    /// The current page of the Products to retrieve</param>
    /// </summary>
    public int Page { get; }

    /// <summary>
    /// The number of pages of the Product to retrieve
    /// </summary>
    public int Size { get; }

    /// <summary>
    /// The order of pages of the Product to retrieve
    /// </summary>
    public string Order { get; }

    /// <summary>
    /// Initializes a new instance of GetProductsCommand
    /// </summary>
    /// <param name="page">The current page of the Products to retrieve</param>
    /// <param name="size">The number of pages of the Product to retrieve</param>
    /// <param name="order">The order of pages of the Product to retrieve</param>
    public GetProductsCommand(int page, int size, string order)
    {
        Page = page;
        Size = size;
        Order = order;
    }
}
