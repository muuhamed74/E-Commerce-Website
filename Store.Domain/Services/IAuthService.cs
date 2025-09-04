using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Store.Domain.DTOs.Identity;
using Store.Domain.Models.Identity;

namespace Store.Domain.Services
{
    public interface IAuthService
    {
        Task<AuthModel> InitSignUpAsync(RegisterDto model);
        Task<AuthModel> LoginAsync(LoginDto model);
        Task<string> AddRoleAsync(AddRoleModel model);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task<bool> RevokeTokenAsync(string token); 
        Task<AuthModel> VerifyCodeAsync(string email, string inputCode);
        Task<SignUpResponseDto> ReSendCode(string email);  
        Task<SendOtpCodeResponceDto> SendOtpCode(SendOtpCodeRequestDto model);
        Task<VerifyOtpResponseDto> VerifyResetPasswordOtpAsync(VerifyOtpRequestDto model);
        Task<ResetPasswordResponseDto> ResetPasswordAsync(ResetPasswordRequestDto model);
        Task<bool> LogoutAsync(string refreshToken);
    }
}
