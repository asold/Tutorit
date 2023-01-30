namespace Tutorit.Models;

public enum BelongsTo
{
    Teacher,
    Student
}

public class UserSubject
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public Guid SubjectId { get; set; }
    public Subject Subject{ get; set; }
    public BelongsTo BelongsTo { get; set; }
    public DateTime TimeChosen { get; set; }
}