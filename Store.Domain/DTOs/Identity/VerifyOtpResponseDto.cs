using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.DTOs.Identity
{
    public class VerifyOtpResponseDto
    {
        public bool IsVerified { get; set; }
        public string? Message { get; set; }
    }
}
