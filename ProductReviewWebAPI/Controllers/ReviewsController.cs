using Microsoft.AspNetCore.Mvc;
using ProductReviewWebAPI.Data;

namespace ProductReviewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Get()
        {
     
        }
    }
}
