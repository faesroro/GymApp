namespace GymApp.Domain.Entities;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

    public string Role { get; set; } = "User"; // Admin, User, etc.

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}