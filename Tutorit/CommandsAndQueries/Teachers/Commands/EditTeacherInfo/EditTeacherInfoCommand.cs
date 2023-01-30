using MediatR;
using Microsoft.EntityFrameworkCore;
using Tutorit.Common.Exceptions;
using Tutorit.Persistance;

namespace Tutorit.CommandsAndQueries.Teachers.Commands.EditTeacherInfo;

public class EditTeacherInfoCommand : IRequest<Guid>
{
    public Guid TeacherId { get; set; }
    public string Description { get; set; }
}

public class EditTeacherInfoCommandHanlder : IRequestHandler<EditTeacherInfoCommand, Guid>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public EditTeacherInfoCommandHanlder(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task<Guid> Handle(EditTeacherInfoCommand request, CancellationToken cancellationToken)
    {
        var teacherToEdit = await _applicationDbContext.Teachers.FirstOrDefaultAsync(x => x.Id == request.TeacherId);

        if (teacherToEdit == null)
        {
            throw new NotFoundException("Teacher not found");
        }

        teacherToEdit.Description = request.Description;

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return teacherToEdit.Id;
    }
}