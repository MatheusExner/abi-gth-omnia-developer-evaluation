using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;
public interface ISaleRepository : IRepository<Sale>
{


    /// <summary>
    /// Gets a list of all Sales, including their Customer, Branch and Items
    /// </summary>
    /// <returns></returns>
    new IQueryable GetAllQueryable();

    /// <summary>
    /// Gets a Sale by its ID, including its Customer, Branch and Items
    /// </summary>
    /// <returns>A Sale</returns>
    new Task<Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}

