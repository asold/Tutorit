using MediatR;
using Tutorit.Models;
using Tutorit.Persistance;

namespace Tutorit.CommandsAndQueries.Registration.Commands;

public class RegisterTeacherCommand : IRequest<Guid>
{
    public UserDto UserDto { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Username { get; set; }
}

public class RegisterTeacherCommandHandler : IRequestHandler<RegisterTeacherCommand, Guid>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public RegisterTeacherCommandHandler(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    
    public async Task<Guid> Handle(RegisterTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacherToRegister = new Teacher()
        {
            FirstName = request.UserDto.FirstName,
            LastName = request.UserDto.FirstName,
            PhotoUrl = request.UserDto.FirstName,
            Email = request.UserDto.Email,
            PasswordHash = request.PasswordHash,
            PasswordSalt = request.PasswordSalt,
            Username = request.Username
        };

        await _applicationDbContext.Teachers.AddAsync(teacherToRegister);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return teacherToRegister.Id;
    }
    
}