using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.DTOs.Identity
{
    public class SendOtpCodeResponceDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
