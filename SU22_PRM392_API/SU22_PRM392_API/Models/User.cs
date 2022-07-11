using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRM392_API.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FullName { get; set; }
        [Required]
        [Phone]
        [Column(TypeName = "varchar(50)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; } = null;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsAdmin { get; set; } = false;
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}