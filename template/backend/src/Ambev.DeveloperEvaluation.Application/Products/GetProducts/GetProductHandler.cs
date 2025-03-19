using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Handler for processing GetProductsCommand requests
/// </summary>
public class GetProductsHandler : IRequestHandler<GetProductsCommand, IQueryable<Product>>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of GetProductssHandler
    /// </summary>
    /// <param name="ProductsRepository">The Products repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetProductsCommand</param>
    public GetProductsHandler(
        IProductRepository productsRepository)
    {
        _productRepository = productsRepository;
    }

    /// <summary>
    /// Handles the GetProductsCommand request
    /// </summary>
    /// <param name="request">The GetProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Products details if found</returns>
    public async Task<IQueryable<Product>> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        return _productRepository.GetAllQueryable();
    }
}
