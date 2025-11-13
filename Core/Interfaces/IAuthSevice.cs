using System;
using Core.Entities;

namespace Core.Interfaces;

public interface IAuthService
{
    LoginResponse? Login(LoginRequest request);
}
