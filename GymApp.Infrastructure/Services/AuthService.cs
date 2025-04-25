using GymApp.Auth.DTOs;
using GymApp.Domain.Entities;
using GymApp.Auth.Services;
using GymApp.Infrastructure.Data;

namespace GymApp.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly AuthDbContext _context;

    public AuthService(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<User?> RegisterAsync(RegisterRequest request)
    {
        if (_context.Users?.Any(u => u.Username == request.Username) ?? false)
            return null;

        var user = new User
        {
            Username = request.Username,
            PasswordHash = request.Password // Esto es sin cifrar por ahora
        };

        
        if (_context.Users != null)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
        else
        {
            // Manejo del error si _context.Users es null (esto no debería ocurrir normalmente)
        }

        return user;
    }

    public async Task<User?> LoginAsync(LoginRequest request)
    {
        return await Task.FromResult(_context.Users
            .FirstOrDefault(u => u.Username == request.Username && u.PasswordHash == request.Password));
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await Task.FromResult(_context.Users.ToList());
    }
}
