using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models.Cart_Models;

namespace Store.Domain.Services
{
    public interface IPaymentService
    {
        Task<UserBasket?> CreateOrUpdatePaymentIntent(string basketId);
    }
}
