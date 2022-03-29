using LogicHandler.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace Persistence.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly QuocThangDbContext _dbContext;


        private DbSet<Product> _dbSet { get; set; }
        public ProductRepository(QuocThangDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<Product>();
        }

        public async Task AddAsync(Product entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Product> entities) => await _dbContext.AddRangeAsync(entities);

        public async Task ModifyAsync(Product entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null) _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Product> GetAll(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, int? pageIndex = null, int? pageSize = null)
        {
            var result = _dbSet.Include(x => x.Category)
                .Include(x => x.Images)
                .Include(x => x.ProductDetails).AsQueryable();
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
            return result;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.Category)
                .Include(x => x.Images)
                .Include(x => x.ProductDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Product> Get(Expression<Func<Product, bool>> filter)
        {
            var result = _dbSet.AsQueryable();

            return result.Where(filter);
        }

        public void DeleteRange(List<Product> entities)
        {
            if (entities.Any())
            {
                _dbContext.RemoveRange(entities);
            }
            _dbContext.SaveChanges();
        }

        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Product, TResult>> selector, Expression<Func<Product, bool>> predicate = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
            bool disableTracking = true)
        {
            IQueryable<Product> query = _dbSet;
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
    }
}
