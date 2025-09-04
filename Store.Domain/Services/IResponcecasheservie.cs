using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Services
{
    public interface IResponcecasheservie
    {
        //cache data
        Task CasheResponceAsync(string Cachekey , object Responce , TimeSpan ExpireTime);


        //get data from cache
        Task<string?> Getcacheresponce (string Cachekey );
    }
}
