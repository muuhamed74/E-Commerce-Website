using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.Domain.Models.Identity;

namespace Store.Domain.Services
{
    public interface ITokenService
    {

        Task<string> CreateTokenAsync(Appuser user, UserManager<Appuser> userManager);
    }
}
