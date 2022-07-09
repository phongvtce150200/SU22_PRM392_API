using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    [Table("PaymentMethod")]
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string PaymentMethodName { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
