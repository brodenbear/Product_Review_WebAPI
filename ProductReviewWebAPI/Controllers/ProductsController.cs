using Microsoft.AspNetCore.Mvc;
using ProductReviewWebAPI.Data;
using ProductReviewWebAPI.Models;
using System.Net.Security;

namespace ProductReviewWebAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
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

        public IActionResult Put(int id, [FromBody] Product product)
        {
            var existingProduct = _context.Products.Find(id);
            if (existingProduct == null)
            { return NotFound(); }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Reviews = product.Reviews;

            _context.SaveChanges();

            return StatusCode(200, existingProduct);
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

        [HttpGet]
        public IActionResult GetAll(int? maxPrice)
        {
            var products = _context.Products.ToList();
            if (maxPrice != null)
            {
                products = products.Where(p => p.Price <= maxPrice).ToList();
            }
            return Ok(products);

        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var products = _context.Products
                .Select(p => new ProductDTO
            {
                AverageRating = p.Reviews.Average(a => a.Rating),
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Reviews = p.Reviews.Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    Text = r.Text,
                    Rating = r.Rating,

                }
                ).ToList()
     

            }).ToList();
          
            return Ok(products);
        }

    }
}
