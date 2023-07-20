using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductReviewWebAPI.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        
        
        
        [ForeignKey("ProductName")]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
    }
}
