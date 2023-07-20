using Microsoft.EntityFrameworkCore;

namespace ProductReviewWebAPI.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }
    }
}
