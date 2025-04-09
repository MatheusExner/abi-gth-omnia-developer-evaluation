using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class SaleRepository : Repository<Sale>, ISaleRepository
{
    protected new readonly DbSet<Sale> _dbSet;

    public SaleRepository(DefaultContext context)
        : base(context)
    {
        _dbSet = context.Set<Sale>();
    }

    /// <summary>
    /// Gets a list of all Sales, including their Customer, Branch and Items
    /// </summary>
    /// <returns>A queryable of Sales</returns>
    public new IQueryable GetAllQueryable()
    {
        return _dbSet
            .Include(x => x.Customer)
            .Include(x => x.Branch)
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .AsQueryable();
    }

    /// <summary>
    /// Gets a Sale by its ID, including its Customer, Branch and Items
    /// </summary>
    /// <returns>A Sale</returns>
    public new async Task<Sale> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(x => x.Customer)
            .Include(x => x.Branch)
            .Include(x => x.Items)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}