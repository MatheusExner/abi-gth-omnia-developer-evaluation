using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;
public interface IBranchRepository : IRepository<Branch>
{ 
    /// <summary>
    /// Gets a Branch by its name
    /// </summary>
    /// <param name="name">The name of the Branch</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Branch?> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}

