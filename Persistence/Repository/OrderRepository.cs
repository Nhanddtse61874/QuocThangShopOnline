using DataAccessLayer.RepositoryInterface;
using Microsoft.EntityFrameworkCore;
using Persistence.EnitityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private QuocThangDbContext _dbContext;

        DbSet<Order> _dbSet { get; set; }

        public OrderRepository(QuocThangDbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<Order>();
        }
        public async Task AddAsync(Order entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<Order> entities) => await _dbContext.AddRangeAsync(entities);

        public async Task DeleteAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null) _dbContext.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public void DeleteRange(List<Order> entities)
        {
            if (entities.Any())
            {
                _dbContext.RemoveRange(entities);
            }
            _dbContext.SaveChanges();
        }

        public IQueryable<Order> Get(Expression<Func<Order, bool>> filter)
        {
            var result = _dbSet.AsQueryable();

            return result.Where(filter);
        }

        public IQueryable<Order> GetAll(Expression<Func<Order, bool>> filter = null,
                Func<IQueryable<Order>,
                IOrderedQueryable<Order>> orderBy = null, int? pageIndex = null, int? pageSize = null,
                Func<IQueryable<Order>, IQueryable<Order>> includeProperties = null)
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
            return result.Include(x => x.OrderDetails).Include(x => x.Customer);
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.OrderDetails)
              .Include(x => x.Customer)
              .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Order, TResult>> selector, Expression<Func<Order, bool>> predicate = null, Func<IQueryable<Order>, IOrderedQueryable<Order>> orderBy = null, bool disableTracking = true)
        {
            IQueryable<Order> query = _dbSet;
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

        public async Task ModifyAsync(Order entity)
        {
            _dbContext.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        private IQueryable<Order> IncludeProperties(Func<IQueryable<Order>, IQueryable<Order>> includeProperties = null)
        {
            return includeProperties == null ? _dbSet : includeProperties(_dbSet);
        }

        public IQueryable<Order> Get(Expression<Func<Order, bool>> filter, Func<IQueryable<Order>, IQueryable<Order>> includeProperties = null)
        {
            throw new NotImplementedException();
        }
    }
}
