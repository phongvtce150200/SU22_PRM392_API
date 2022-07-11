using System.ComponentModel.DataAnnotations;

namespace SU22_PRM392_API.Models
{
    public class CategoryModelView
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
