﻿

using Laboratory.Services.AuthAPI.Models.Dto;

namespace Laboratory.Services.AuthAPI.Services.IServices
{
    public interface IAuthService
    {
        Task<string>  Register(RegisterationRequestDto registerationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<bool> AssignRole(string email, string roleName);
    }
}
