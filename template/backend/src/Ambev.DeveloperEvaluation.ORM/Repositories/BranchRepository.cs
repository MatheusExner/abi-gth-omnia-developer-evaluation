using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class BranchRepository : Repository<Branch>, IBranchRepository
{
    protected new readonly DbSet<Branch> _dbSet;

    public BranchRepository(DefaultContext context)
        : base(context)
    {
        _dbSet = context.Set<Branch>();
    }

    /// <summary>
    /// Gets a Branch by its name
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Branch?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Name == name,
                                                cancellationToken);
    }
}