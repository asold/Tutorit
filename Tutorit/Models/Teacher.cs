using System.Collections.ObjectModel;

namespace Tutorit.Models;

public class Teacher : User
{
    public string? Description { get; set; }
    public decimal Rating { get; set; }
}