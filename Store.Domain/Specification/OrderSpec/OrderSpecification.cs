using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models.Order_Models;

namespace Store.Domain.Specification.OrderSpec
{
    public class OrderSpecification : BaseSpecification<Order>
    {

        public OrderSpecification(string email):base(O => O.BuyerEmail == email)
        {
            Includes.Add(O => O.DeliveryMethod);
            Includes.Add(O => O.Items);
            AddOrderByDesending(O => O.OrderDate);
        }

        public OrderSpecification(int orderid , string email) : base(O => O.Id == orderid && O.BuyerEmail == email)
        {
            Includes.Add(O => O.DeliveryMethod);
            Includes.Add(O => O.Items);
        }
    }
}
