using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.DTOs.Cart
{
    public class BasketItemDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage ="Price can not be zero")]
        public decimal Price { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="quantity can not be zero")]
        public int Quantity { get; set; }
    }
}
