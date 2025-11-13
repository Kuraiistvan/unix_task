using System;
using Core.Interfaces;
using Core.Entities;
using Infrastructure.Services;

namespace Infrastructure.Data;

public class AuthService : IAuthService
{
    public LoginResponse? Login(LoginRequest request)
    {
        if (request.Username == "test" && request.Password == "1234")
        {
            var token = TokenService.GenerateToken(request.Username);
            return new LoginResponse
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddHours(1)
            };
        }

        return null;
    }
}
