using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models.Order_Models;

namespace Store.Domain.Specification.OrderSpec
{
    public class OrderWithPaymentWithSpec : BaseSpecification<Order>
    {
        public OrderWithPaymentWithSpec(string paymentIntentId)
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
            //AddInclude(o => o.Items);
            //AddInclude(o => o.DeliveryMethod);
        }
    }
}
