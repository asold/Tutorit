using Tutorit.Models;

namespace Tutorit.CommandsAndQueries.Registration;

public class AccountDto
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
    public bool RememberMe { get; set; }
}