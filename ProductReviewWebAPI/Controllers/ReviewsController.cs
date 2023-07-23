using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Post([FromBody] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Reviews.Add(review);
                _context.SaveChanges();
                return StatusCode(201, review);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] Review review)
        {
            var existingReview = _context.Reviews.Find(id);
            if (existingReview == null)
            { return NotFound(); }

            existingReview.Text = review.Text;
            existingReview.Product = review.Product;
            existingReview.Rating = review.Rating;
            existingReview.ProductID = review.ProductID;

            _context.SaveChanges();

            return StatusCode(200, existingReview);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("search/{keyword}")]
        public IActionResult GetByProductId(int? productId)
        {
            var reviews = _context.Reviews.ToList();
            if (productId != null)
            {
                reviews = reviews.Where(r => r.ProductID == productId).ToList();
            }
            return Ok(reviews);
        }
    }
}




