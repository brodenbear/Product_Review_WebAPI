using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductReviewWebAPI.Data;
using ProductReviewWebAPI.Models;

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
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
           
            var review = _context.Reviews.SingleOrDefault(review => review.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }
        [HttpPost]
        public IActionResult Post(Product product) 
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return StatusCode(201, product);
            }
            return BadRequest(ModelState);
        }
    }
}
