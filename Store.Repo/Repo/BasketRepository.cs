using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using Store.Domain.Models.Cart_Models;
using Store.Domain.Services;

namespace Store.Repo.Repo
{
    public class BasketRepository : IBasketRepository
    {

        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }




        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }




        public async Task<UserBasket?> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);
            return data.IsNull ? null : JsonSerializer.Deserialize<UserBasket>(data!); // this code is better and simple



            //if (data.IsNullOrEmpty) return new UserBasket { Id = basketId };
            //return JsonSerializer.Deserialize<UserBasket>(data!);
        }




        public async Task<UserBasket?> UpdateBasketAsync(UserBasket basket)
        {
            var serializedBasket = JsonSerializer.Serialize(basket);
            var created = await _database.StringSetAsync(basket.Id, serializedBasket, TimeSpan.FromDays(2));
            if (!created) return null;

            return await GetBasketAsync(basket.Id);
        }
    }
}
