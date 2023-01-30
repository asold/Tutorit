using MediatR;
using Microsoft.EntityFrameworkCore;
using Tutorit.Common.Exceptions;
using Tutorit.Models;
using Tutorit.Persistance;

namespace Tutorit.CommandsAndQueries.Users.Commands.UserSubjects;

public class ChooseSubjectByUserCommand : IRequest
{
    public Guid UserId { get; set; }
    public Guid SubjectId { get; set; }
}

public class ChooseSubjectByUserCommandHandler : IRequestHandler<ChooseSubjectByUserCommand>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public ChooseSubjectByUserCommandHandler(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task<Unit> Handle(ChooseSubjectByUserCommand request, CancellationToken cancellationToken)
    {
        var neededUser = await _applicationDbContext.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
        var neededSubject = await _applicationDbContext.Subjects.FirstOrDefaultAsync(x => x.Id == request.SubjectId);

        if (neededSubject == null || neededUser == null)
        {
            throw new NotFoundException("User or Subject not found");
        }

        if (neededUser.GetType() == typeof(Student))
        {
            var userSubject = new UserSubject()
            {
                UserId = request.UserId,
                SubjectId = request.SubjectId,
                BelongsTo = BelongsTo.Student,
                TimeChosen = DateTime.UtcNow
            };

            await _applicationDbContext.UserSubjects.AddAsync(userSubject);
        }
        
        if (neededUser.GetType() == typeof(Teacher))
        {
            var userSubject = new UserSubject()
            {
                UserId = request.UserId,
                SubjectId = request.SubjectId,
                BelongsTo = BelongsTo.Teacher,
                TimeChosen = DateTime.UtcNow
            };

            await _applicationDbContext.UserSubjects.AddAsync(userSubject);
        }

        return Unit.Value;
    }
}