using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace LogicHandler.RepositoryInterface
{
    public interface IOrderDetailRepository
    {
        Task AddAsync(OrderDetail entity);

        Task AddRangeAsync(IEnumerable<OrderDetail> entities);

        Task ModifyAsync(OrderDetail entity);

        Task DeleteAsync(int id);

        IQueryable<OrderDetail> GetAll(
             Expression<Func<OrderDetail, bool>> filter = null,
             Func<IQueryable<OrderDetail>, IOrderedQueryable<OrderDetail>> orderBy = null,
             int? pageIndex = null, int? pageSize = null,
             Func<IQueryable<OrderDetail>, IQueryable<OrderDetail>> include = null
             );

        Task<OrderDetail> GetByIdAsync(int id, Func<IQueryable<OrderDetail>, IQueryable<OrderDetail>> includeProperties = null);

        IQueryable<OrderDetail> Get(Expression<Func<OrderDetail, bool>> filter, Func<IQueryable<OrderDetail>, IQueryable<OrderDetail>> includeProperties = null);

        void DeleteRange(List<OrderDetail> entities);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<OrderDetail, TResult>> selector,
                                          Expression<Func<OrderDetail, bool>> predicate = null,
                                          Func<IQueryable<OrderDetail>, IOrderedQueryable<OrderDetail>> orderBy = null,
                                          Func<IQueryable<OrderDetail>, IQueryable<OrderDetail>> include = null,
                                          bool disableTracking = true);
    }
}
