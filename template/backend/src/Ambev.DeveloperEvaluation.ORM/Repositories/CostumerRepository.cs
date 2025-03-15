using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

public class CostumerRepository : Repository<Customer>, ICostumerRepository
{
    public CostumerRepository(DefaultContext context)
        : base(context)
    {
    }
}