using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using StackExchange.Redis;
using Store.Domain.Services;

namespace Store.Serv.Services
{
    public class Responsecachservice : IResponcecasheservie
    {
        private readonly IDatabase _database;

        public Responsecachservice(IConnectionMultiplexer Redis)
        {
            _database = Redis.GetDatabase();
        }
        public async Task CasheResponceAsync(string Cachekey, object Responce, TimeSpan ExpireTime)
        {
            if (Responce == null) return;
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            var JsonResponce = JsonSerializer.Serialize(Responce , options);
            await _database.StringSetAsync(Cachekey, JsonResponce, ExpireTime);



        }

        public async Task<string?> Getcacheresponce(string Cachekey)
        {
            var cachresponce = await _database.StringGetAsync(Cachekey);
            if (cachresponce.IsNullOrEmpty) return null;
            return cachresponce;
        }
    }
}
