using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string Id { get; set; }
        [ForeignKey("Id")]
        public User User { get; set; }
        public ICollection<CartDetails> CartDetails {get; set;}
    }
}
