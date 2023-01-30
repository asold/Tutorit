using MediatR;
using Microsoft.EntityFrameworkCore;
using Tutorit.Common.Exceptions;
using Tutorit.Models;
using Tutorit.Persistance;

namespace Tutorit.CommandsAndQueries.Subjects.Commands;

public class AddSubjectCommand : IRequest<Guid>
{
    public string Name { get; set; }
}

public class AddSubjectCommandHandler : IRequestHandler<AddSubjectCommand, Guid>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public AddSubjectCommandHandler(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task<Guid> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
    {
        if (await _applicationDbContext.Subjects.AnyAsync(x => x.Name == request.Name))
        {
            throw new ConflictException("Subject already exists");
        }

        var subject = new Subject()
        {
            Name = request.Name
        };

        await _applicationDbContext.Subjects.AddAsync(subject);
        await _applicationDbContext.SaveChangesAsync();

        return subject.Id;

    }
}