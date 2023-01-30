using System.Collections.ObjectModel;

namespace Tutorit.Models;

public abstract class User
{
    public Guid Id { get; set; }
    public DateTime RegisteredAt { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhotoUrl { get; set; }
    public string Email { get; set; }
    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? TokenCreated { get; set; }
    public DateTime? TokenExpires { get; set; }
    public string Username { get; set; }
    public Account Account { get; set; }
    public ICollection<UserSubject> UserSubjects { get; set; } = new Collection<UserSubject>();


}