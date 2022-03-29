using Microsoft.EntityFrameworkCore;
using Persistence.EnitityModel;

namespace Persistence
{
    public class QuocThangDbContext : DbContext
    {
        public QuocThangDbContext(DbContextOptions<QuocThangDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<ImageStorage> ImageStorage { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductDetail> ProductDetail { get; set; }
        public DbSet<ProductDetailImageStorage> ProductDetailImageStorage { get; set; }
        public DbSet<ProductImageStorage> ProductImageStorage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
