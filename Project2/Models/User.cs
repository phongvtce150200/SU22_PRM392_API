using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models
{
    [Table("User")]
    public class User : IdentityUser
    {
        [MaxLength(250)]
        [Required(ErrorMessage = "First Name of user can't be blank")]
        public string FirstName { get; set; }
        [MaxLength(250)]
        [Required(ErrorMessage = "Last Name of user can't be blank")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(max)")]
        public string ImageUrl { get; set; } = null;
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Today;
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders {get; set;}
        
    }
}
