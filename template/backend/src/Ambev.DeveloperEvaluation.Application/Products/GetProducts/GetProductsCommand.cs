using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Command for retrieving a list of Products
/// </summary>
public record GetProductsCommand : IRequest<IQueryable<Product>>
{

}
