using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Store.Domain.Models.Identity
{
    // owend by AppUser
    [Owned]
    public class RefreshToken
    {
        public string Token { get; set; }
        public DateTime ExpiersOn { get; set; }
        public bool IsExpierd => DateTime.UtcNow > ExpiersOn;
        public DateTime CreatedOn { get; set; }
        public DateTime? RevokedOn { get; set; }
        public bool IsActive => !IsExpierd && RevokedOn == null;
    }
}
