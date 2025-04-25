using System;
using GymApp.Auth.DTOs;
using GymApp.Domain.Entities;

namespace GymApp.Auth.Services;

public interface IAuthService
{
    Task<User?> RegisterAsync(RegisterRequest request);
    Task<User?> LoginAsync(LoginRequest request);
    Task<List<User>> GetAllAsync();

}
