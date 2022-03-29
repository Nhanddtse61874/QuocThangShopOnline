using LogicHandler.InterfaceRepository;
using Persistence.EnitityModel;
using System.Linq.Expressions;

namespace ClassLibrary1
{
    public class Class1 : IProductRepository
    {
        public Task AddAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<Product> entities)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetAll(Expression<Func<Product, bool>> filter = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, int? pageIndex = null, int? pageSize = null)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<Product, TResult>> selector, Expression<Func<Product, bool>> predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task ModifyAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}