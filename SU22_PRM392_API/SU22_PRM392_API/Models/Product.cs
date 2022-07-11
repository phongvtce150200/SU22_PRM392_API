using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRM392_API.Models
{

    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Name of Product can't be blank")]
        [MaxLength(50)]
        public string ProductName { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; } = null;
        [Required(ErrorMessage = "Price of product can't be blank")]
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string ImagePath { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Today;
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public ICollection<CartDetails> CartDetails { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
