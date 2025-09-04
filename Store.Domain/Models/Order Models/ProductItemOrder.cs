using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Models.Order_Models
{
    public class ProductItemOrder
    {
        public ProductItemOrder()
        {
        }
        public ProductItemOrder(int productId, string? productName, string? productImages)
        {
            ProductId = productId;
            ProductName = productName;
            ProductImages = productImages;
        }

        public int ProductId {  get; set; }
        public string? ProductName {  get; set; }
        public string? ProductImages {  get; set; }
    }
}
