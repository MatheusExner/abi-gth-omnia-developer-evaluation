using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;
public interface IProductRepository : IRepository<Product>
{
    /// <summary>
    /// Gets a Product by its name
    /// </summary>
    /// <param name="name">The name of the product</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}

