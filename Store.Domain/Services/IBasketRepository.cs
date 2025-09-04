using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.Domain.Models.Cart_Models;

namespace Store.Domain.Services
{
    public interface IBasketRepository
    {
        Task<UserBasket?> GetBasketAsync(string basketId);
        Task<UserBasket?> UpdateBasketAsync(UserBasket basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
