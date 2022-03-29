using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace LogicHandler.RepositoryInterface
{
    public interface IProductDetailRepository
    {
        Task AddAsync(ProductDetail entity);

        Task AddRangeAsync(IEnumerable<ProductDetail> entities);

        Task ModifyAsync(ProductDetail entity);

        Task DeleteAsync(int id);

        IQueryable<ProductDetail> GetAll(
             Expression<Func<ProductDetail, bool>> filter = null,
             Func<IQueryable<ProductDetail>, IOrderedQueryable<ProductDetail>> orderBy = null,
             int? pageIndex = null, int? pageSize = null,
             Func<IQueryable<ProductDetail>, IQueryable<ProductDetail>> include = null
             );

        Task<Order> GetByIdAsync(int id, Func<IQueryable<ProductDetail>, IQueryable<ProductDetail>> includeProperties = null);

        IQueryable<ProductDetail> Get(Expression<Func<ProductDetail, bool>> filter, Func<IQueryable<ProductDetail>, IQueryable<ProductDetail>> includeProperties = null);

        void DeleteRange(List<ProductDetail> entities);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<ProductDetail, TResult>> selector,
                                          Expression<Func<ProductDetail, bool>> predicate = null,
                                          Func<IQueryable<ProductDetail>, IOrderedQueryable<ProductDetail>> orderBy = null,
                                          Func<IQueryable<ProductDetail>, IQueryable<ProductDetail>> include = null,
                                          bool disableTracking = true);
    }
}
