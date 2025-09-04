using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stripe;

namespace Store.Domain.Models.Order_Models
{
    public class Order : BaseModel
    {
        public Order() 
        {
        }
        public Order(string? buyerEmail, Address? shipToAddress, DeliveryMethod? deliveryMethod, ICollection<OrderItems>? items, decimal subtotal , string paymentIntent)
        {
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            Items = items;
            Subtotal = subtotal;
            PaymentIntentId = paymentIntent;
        }

        public string? BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address? ShipToAddress { get; set; }
        public DeliveryMethod? DeliveryMethod { get; set; }
        public ICollection<OrderItems>? Items { get; set; } = new HashSet<OrderItems>();
        public decimal Subtotal { get; set; }

        public decimal GetTotal() =>  Subtotal + DeliveryMethod.Cost; 
       
        public string? PaymentIntentId { get; set; }  
    }
}
