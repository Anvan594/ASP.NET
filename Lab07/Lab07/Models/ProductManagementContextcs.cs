using Microsoft.EntityFrameworkCore;
namespace Lab07.Models
{
    public class ProductManagementContextcs : DbContext
    {
        public ProductManagementContextcs(DbContextOptions<ProductManagementContextcs> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Banner> Banners { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
    }
}
