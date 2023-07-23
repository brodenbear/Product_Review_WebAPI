using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductReviewWebAPI.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        
        
        
        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public string Product { get; set; }
    }
}
