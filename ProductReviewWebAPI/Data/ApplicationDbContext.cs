using Microsoft.EntityFrameworkCore;
using ProductReviewWebAPI.Models;
using ProductReviewWebAPI.Data;
using ProductReviewWebAPI.Models;

namespace ProductReviewWebAPI.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Product> Products { get; set; }
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }
    }
}
