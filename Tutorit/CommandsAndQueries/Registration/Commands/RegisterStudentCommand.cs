using MediatR;
using Tutorit.Models;
using Tutorit.Persistance;

namespace Tutorit.CommandsAndQueries.Registration.Commands;

public class RegisterStudentCommand : IRequest<Guid>
{
    public UserDto UserDto { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string Username { get; set; }
}

public class RegisterStudentCommandHandler : IRequestHandler<RegisterStudentCommand, Guid>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public RegisterStudentCommandHandler(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Guid> Handle(RegisterStudentCommand request, CancellationToken cancellationToken)
    {
        var studentToRegister = new Student()
        {
            FirstName = request.UserDto.FirstName,
            LastName = request.UserDto.FirstName,
            PhotoUrl = request.UserDto.FirstName,
            Email = request.UserDto.Email,
            PasswordHash = request.PasswordHash,
            PasswordSalt = request.PasswordSalt,
            Username = request.Username
        };

        await _applicationDbContext.Students.AddAsync(studentToRegister);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return studentToRegister.Id;
    }
}