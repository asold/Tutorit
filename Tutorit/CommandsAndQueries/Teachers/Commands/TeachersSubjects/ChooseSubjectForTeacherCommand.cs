using MediatR;

namespace Tutorit.CommandsAndQueries.Teachers.Commands.TeachersSubjects;

public class ChooseSubjectForTeacherCommand : IRequest
{
    public Guid TeacherId { get; set; }
    public Guid SubjectId { get; set; }
    public DateTime TimeChosen { get; set; }
}

