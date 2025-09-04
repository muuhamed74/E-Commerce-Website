using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Models
{
    public class Product : BaseModel
    {

        [Required]
        public string? Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        // Foreign Key to Category
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        // Navigation Property to Images
        public ICollection<Images>? Images { get; set; }
    }
}
