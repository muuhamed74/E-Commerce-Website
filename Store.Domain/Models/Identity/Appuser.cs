using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Store.Domain.Models.Identity
{
    public class Appuser : IdentityUser
    {
        public string Name { get; set; }

        public Adress Adress { get; set; }

        public List<RefreshToken>? RefreshTokens { get; set; }

        public DateTime? RefreshTokenExpiration { get; set; }

    }
}
