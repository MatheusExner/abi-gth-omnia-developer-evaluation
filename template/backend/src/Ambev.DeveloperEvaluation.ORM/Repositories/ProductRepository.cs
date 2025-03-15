using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    protected new readonly DbSet<Product> _dbSet;

    public ProductRepository(DefaultContext context)
        : base(context)
    {
        _dbSet = context.Set<Product>();
    }

    public async Task<Product?> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Name == name,
                                                cancellationToken);
    }
}