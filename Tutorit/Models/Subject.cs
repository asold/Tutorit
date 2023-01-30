using System.Collections.ObjectModel;

namespace Tutorit.Models;

public class Subject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserSubject> UserSubjects { get; set; } = new Collection<UserSubject>();

}