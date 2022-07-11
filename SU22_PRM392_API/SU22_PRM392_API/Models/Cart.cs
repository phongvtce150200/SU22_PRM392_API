using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRM392_API.Models
{

    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool CartStatus { get; set; }
        [ForeignKey("Id")]
        public User User { get; set; }
        public ICollection<CartDetails> CartDetails { get; set; }
    }
}
