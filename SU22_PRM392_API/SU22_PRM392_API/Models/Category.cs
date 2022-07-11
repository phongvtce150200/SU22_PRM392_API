using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU22_PRM392_API.Models
{

    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string CategoryName { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<Product> Products { get; set; }

    }
}

