namespace Tutorit.Models;

public enum Role
{
    Teacher = 0,
    Student,
    Admin
}

public class Account
{
    public string Username { get; set; }
    public Role Role { get; set; }
    public bool RememberMe { get; set; }
    public Guid? UserId { get; set; }
}