namespace ProductReviewWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
