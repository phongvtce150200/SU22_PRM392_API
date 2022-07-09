using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project2.Models
{
    [Table("CartDetails")]
    public class CartDetails
    {
        [Key]
        public int CartDetailsId { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool CartStatus { get; set; } = false;
        [Column(TypeName = "Money")]
        public decimal TotalMoney { get; set; }
        [ForeignKey("CartId")]
        public virtual Cart Cart { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}