using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace DataAccessLayer.RepositoryInterface
{
    public interface IOrderRepository 
    { 
        Task AddAsync(Order entity);

        Task AddRangeAsync(IEnumerable<Order> entities);

        Task ModifyAsync(Order entity);

        Task DeleteAsync(int id);

        IQueryable<Order> GetAll(
             Expression<Func<Order, bool>> filter = null,
             Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
             int? pageIndex = null, int? pageSize = null,
             Func<IQueryable<Order>, IQueryable<Order>> include = null
             );

        Task<Order> GetByIdAsync(int id);

        IQueryable<Order> Get(Expression<Func<Order, bool>> filter);

        void DeleteRange(List<Order> entities);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Order, TResult>> selector,
                                          Expression<Func<Order, bool>> predicate = null,
                                          Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null,
                                          bool disableTracking = true);
    }
}
