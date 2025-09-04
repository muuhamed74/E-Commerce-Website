using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Models.Order_Models
{
    public class OrderItems : BaseModel
    {
        public OrderItems() 
        {
        }
        public OrderItems(ProductItemOrder? product, int quantity, decimal price)
        {
            Product = product;
            Quantity = quantity;
            Price = price;
        }

        public ProductItemOrder? Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
