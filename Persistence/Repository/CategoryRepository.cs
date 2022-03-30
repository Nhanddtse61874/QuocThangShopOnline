using MediatorHandler.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace Persistence.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private QuocThangDbContext _dbContext;

        DbSet<Category> _dbSet { get; set; }

        public CategoryRepository(QuocThangDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<Category>();
        }
        public async Task AddAsync(Category entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Category> entities) => await _dbContext.AddRangeAsync(entities);

        public async  Task DeleteAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null) _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteRange(List<Category> entities)
        {
            if (entities.Any())
            {
                _dbContext.RemoveRange(entities);
            }
            _dbContext.SaveChanges();
        }

        public IQueryable<Category> Get(Expression<Func<Category, bool>> filter)
        {
            var result = _dbSet.AsQueryable();

            return result.Where(filter);
        }

        public IQueryable<Category> GetAll(Expression<Func<Category, bool>> filter = null, 
                Func<IQueryable<Category>, 
                IOrderedQueryable<Category>> orderBy = null, int? pageIndex = null, int? pageSize = null, 
                Func<IQueryable<Category>, IQueryable<Category>> includeProperties = null)
        {
            var result = IncludeProperties(includeProperties);
               
            if (filter != null)
            {
                result = result.Where(filter);
            }
            if (orderBy != null)
            {
                result = orderBy(result);
            }
            if (pageIndex != null && pageSize != null)
            {
                result = result.Skip((pageIndex.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return result.Include(x => x.Parent); ;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.Products)
              .Include(x => x.Parent)
              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async  Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Category, TResult>> selector, Expression<Func<Category, bool>> predicate = null, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null, bool disableTracking = true)
        {
            IQueryable<Category> query = _dbSet;
            if (disableTracking)
            {
                query = _dbSet.AsNoTracking();
            }

            if (predicate != null)
            {
                query = _dbSet.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(_dbSet).Select(selector).FirstOrDefaultAsync();
            }
            else
            {
                return await _dbSet.Select(selector).FirstOrDefaultAsync();
            }
        }

        public async Task ModifyAsync(Category entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<Category> IncludeProperties(Func<IQueryable<Category>, IQueryable<Category>> includeProperties = null)
        {
            return includeProperties == null ? _dbSet : includeProperties(_dbSet);
        }
    }
}
