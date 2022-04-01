using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace LogicHandler.RepositoryInterface
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer entity);

        Task AddRangeAsync(IEnumerable<Customer> entities);

        Task ModifyAsync(Customer entity);

        Task DeleteAsync(int id);

        IQueryable<Customer> GetAll(
             Expression<Func<Customer, bool>> filter = null,
             Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null,
             int? pageIndex = null, int? pageSize = null,
             Func<IQueryable<Customer>, IQueryable<Customer>> include = null
             );

        Task<Customer> GetByIdAsync(int id);

        IQueryable<Customer> Get(Expression<Func<Customer, bool>> filter);

        void DeleteRange(List<Customer> entities);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Customer, TResult>> selector,
                                          Expression<Func<Customer, bool>> predicate = null,
                                          Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null,
                                          bool disableTracking = true);
    }
}
