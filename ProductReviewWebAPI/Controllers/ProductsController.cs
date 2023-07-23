using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductReviewWebAPI.Data;
using ProductReviewWebAPI.Models;

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
    }
}
