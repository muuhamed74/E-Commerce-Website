using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models.Order_Models;

namespace Store.Domain.DTOs.Orders
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        public string? BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string Status { get; set; } 
        public Address? ShipToAddress { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal DeleveryCost { get; set; }
        public ICollection<OrderItemsDto>? Items { get; set; } = new HashSet<OrderItemsDto>();
        public decimal Subtotal { get; set; }

        public decimal Total { get; set; }

        public string? PaymentIntentId { get; set; }
    }
}
