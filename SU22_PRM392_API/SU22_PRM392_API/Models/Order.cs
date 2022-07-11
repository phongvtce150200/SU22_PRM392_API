using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRM392_API.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ShippedDate { get; set; } = DateTime.UtcNow;
        public float Voucher { get; set; }
        [Column(TypeName = "Money")]
        public decimal Freight { get; set; }
        public string ShipAddress { get; set; }
        [Column(TypeName = "Money")]
        public decimal TotalPrice { get; set; }
        public bool OrderStatus { get; set; }
        [ForeignKey("Id")]
        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}