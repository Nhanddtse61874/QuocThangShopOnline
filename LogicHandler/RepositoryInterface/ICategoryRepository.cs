using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace MediatorHandler.RepositoryInterface
{
    public interface ICategoryRepository
    {
        Task AddAsync(Category entity);

        Task AddRangeAsync(IEnumerable<Category> entities);

        Task ModifyAsync(Category entity);

        Task DeleteAsync(int id);

        IQueryable<Category> GetAll(
             Expression<Func<Category, bool>> filter = null,
             Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null,
             int? pageIndex = null, int? pageSize = null,
             Func<IQueryable<Category>, IQueryable<Category>> include = null
             );

        Task<Category> GetByIdAsync(int id, Func<IQueryable<Category>, IQueryable<Category>> includeProperties = null);

        IQueryable<Category> Get(Expression<Func<Category, bool>> filter, Func<IQueryable<Category>, IQueryable<Category>> includeProperties = null);

        void DeleteRange(List<Category> entities);

        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Category, TResult>> selector,
                                          Expression<Func<Category, bool>> predicate = null,
                                          Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null,
                                          Func<IQueryable<Category>, IQueryable<Category>> include = null,
                                          bool disableTracking = true);
    }
}
