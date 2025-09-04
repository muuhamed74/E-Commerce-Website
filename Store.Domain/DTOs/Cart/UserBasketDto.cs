using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models.Cart_Models;

namespace Store.Domain.DTOs.Cart
{
    public class UserBasketDto
    {
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public int? DeliveryMethod { get; set; }
    }
}
