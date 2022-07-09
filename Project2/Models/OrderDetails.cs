using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int PaymentMethodId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "Money")]
        public decimal TotalPrice { get; set; }
        public bool OrderStatus { get; set; } = false;
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [ForeignKey("PaymentMethodId")]
        public PaymentMethod PaymentMethod { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
