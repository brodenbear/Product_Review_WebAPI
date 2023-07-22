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
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return StatusCode(201, product);
            }
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]

        public IActionResult Put(int id, [FromBody] Review review)
        {
            var existingReview = _context.Reviews.Find(id);
            if (existingReview == null)
                return NotFound();

            // Assuming you handle validation and other operations before updating the review
            existingReview.Title = review.Title;
            existingReview.ProductName = review.ProductName;
            existingReview.Rating = review.Rating;
            existingReview.ProductID = review.ProductID;

            _context.SaveChanges();

            return StatusCode(200, existingReview);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("search/{keyword}")]
        public IActionResult GetByProductId(int productId)
        {
            var review = _context.Reviews
         .Include(p => p.ProductID)
         .FirstOrDefault(p => p.Id == productId);
                return Ok(review);


        }
    }
}




