using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;
public interface ICustomerRepository : IRepository<Customer>
{
    /// <summary>
    /// Gets a Customer by its name
    /// </summary>
    /// <param name="name">The name of the Customer</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Customer?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}

