using System.ComponentModel.DataAnnotations;

namespace SU22_PRM392_API.Models
{
    public class ProductModelView
    {
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; } = null;
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; } = null;
        [Required]
        public int CategoryId { get; set; }
    }
}
