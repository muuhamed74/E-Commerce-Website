﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Models.Cart_Models
{
    public class UserBasket
    {

        public string? Id { get; set; } 
        public List<BasketItem>? Items { get; set; } 
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public int? DeliveryMethodId { get; set; }
        public UserBasket(string id) 
        { 
            Id = id;
        }
    }
}
