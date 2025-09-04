using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.DTOs.Identity;

namespace Store.Domain.DTOs.Orders
{
    public class OrderDto
    {
        [Required]
        public string? BasketId { get; set; }
        public int DeliveryMethodId { get; set; }
        public AddressDto? ShippingAddress { get; set; }
    }
}
