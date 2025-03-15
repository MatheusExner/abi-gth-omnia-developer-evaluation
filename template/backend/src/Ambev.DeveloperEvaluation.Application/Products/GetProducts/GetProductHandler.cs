using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Ambev.DeveloperEvaluation.Application.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Handler for processing GetProductsCommand requests
/// </summary>
public class GetProductsHandler : IRequestHandler<GetProductsCommand, PaginatedProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetProductssHandler
    /// </summary>
    /// <param name="ProductsRepository">The Products repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetProductsCommand</param>
    public GetProductsHandler(
        IProductRepository productsRepository,
        IMapper mapper)
    {
        _productRepository = productsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductsCommand request
    /// </summary>
    /// <param name="request">The GetProducts command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Products details if found</returns>
    public async Task<PaginatedProductResponse> Handle(GetProductsCommand request, CancellationToken cancellationToken)
    {
        var productsQuery = _productRepository.GetAllQueryable();

        // Apply ordering if requested
        if (!string.IsNullOrEmpty(request.Order))
        {
            var orderBy = request.Order.Split(',').ToList();
            foreach (var sort in orderBy)
            {
                var parts = sort.Trim().Split(' ');
                var property = parts[0];
                var direction = parts.Length > 1 && parts[1].ToLower() == "desc" ? "desc" : "asc";

                // Simple implementation of ordering based on property (extend for more complex sorting if needed)
                if (direction == "asc")
                {
                    productsQuery = productsQuery.OrderBy(p => EF.Property<object>(p, property));
                }
                else
                {
                    productsQuery = productsQuery.OrderByDescending(p => EF.Property<object>(p, property));
                }
            }
        }

        // Use the PaginatedList to fetch the paginated results
        var paginatedProducts = await PaginatedList<Product>.CreateAsync(productsQuery, request.Page, request.Size);

        // Return the PaginatedProductResponse with metadata
        return new PaginatedProductResponse
        {
            Data = paginatedProducts.ToList(),
            TotalItems = paginatedProducts.TotalCount,
            CurrentPage = paginatedProducts.CurrentPage,
            TotalPages = paginatedProducts.TotalPages
        };
    }
}
