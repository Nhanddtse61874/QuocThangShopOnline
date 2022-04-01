using LogicHandler.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace Persistence.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private QuocThangDbContext _dbContext;

        DbSet<Customer> _dbSet { get; set; }

        public CustomerRepository(QuocThangDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<Customer>();
        }
        public async Task AddAsync(Customer entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Customer> entities) => await _dbContext.AddRangeAsync(entities);

        public async Task DeleteAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null) _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteRange(List<Customer> entities)
        {
            if (entities.Any())
            {
                _dbContext.RemoveRange(entities);
            }
            _dbContext.SaveChanges();
        }

        public IQueryable<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            var result = _dbSet.AsQueryable();

            return result.Where(filter);
        }

        public IQueryable<Customer> GetAll(Expression<Func<Customer, bool>> filter = null,
                Func<IQueryable<Customer>,
                IOrderedQueryable<Customer>> orderBy = null, int? pageIndex = null, int? pageSize = null,
                Func<IQueryable<Customer>, IQueryable<Customer>> includeProperties = null)
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
            return result;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Customer, TResult>> selector, Expression<Func<Customer, bool>> predicate = null, Func<IQueryable<Customer>, IOrderedQueryable<Customer>> orderBy = null, bool disableTracking = true)
        {
            IQueryable<Customer> query = _dbSet;
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

        public async Task ModifyAsync(Customer entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<Customer> IncludeProperties(Func<IQueryable<Customer>, IQueryable<Customer>> includeProperties = null)
        {
            return includeProperties == null ? _dbSet : includeProperties(_dbSet);
        }

        
    }
}
