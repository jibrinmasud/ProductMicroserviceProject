using Microsoft.EntityFrameworkCore;

namespace ProductMicroservicesProject.Models
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
    }
}