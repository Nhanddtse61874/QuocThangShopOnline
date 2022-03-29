using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace LogicHandler.RepositoryInterface
{
    public interface IProductRepository
    {
        Task AddAsync(Product entity);

        Task AddRangeAsync(IEnumerable<Product> entities);

        Task ModifyAsync(Product entity);
        Task DeleteAsync(int id);

        IQueryable<Product> GetAll(
             Expression<Func<Product, bool>> filter = null,
             Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
             int? pageIndex = null, int? pageSize = null);

        Task<Product> GetByIdAsync(int id);

        IQueryable<Product> Get(Expression<Func<Product, bool>> filter);

        void DeleteRange(List<Product> entities);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Product, TResult>> selector,
                                          Expression<Func<Product, bool>> predicate = null,
                                          Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
                                          bool disableTracking = true);
    }
}
