using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    protected new readonly DbSet<Customer> _dbSet;

    public CustomerRepository(DefaultContext context)
        : base(context)
    {
        _dbSet = context.Set<Customer>();
    }

    /// <summary>
    /// Gets a Customer by its name
    /// </summary>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Customer?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Name == name,
                                                cancellationToken);
    }
}