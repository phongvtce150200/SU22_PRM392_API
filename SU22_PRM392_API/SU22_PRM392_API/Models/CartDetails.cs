using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRM392_API.Models
{

    [Table("CartDetails")]
    public class CartDetails
    {
        [Key]
        public int CartId { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
