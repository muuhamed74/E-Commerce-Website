using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Models
{
    public class Category : BaseModel
    {

        [Required]
        public string Name { get; set; }

        // Navigation Property
        public ICollection<Product> Products { get; set; }
       
    }
}
