using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tutorit.Models;
using Tutorit.Persistance;
using Tutorit.Services;

namespace Tutorit.CommandsAndQueries.Registration.Commands;

public class RegistrationCommand : IRequest<User>
{
    public AccountDto AccountDto { get; set; }
    public UserDto UserDto { get; set; }
}

public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, User>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IPasswordService _passwordService;
    private readonly ISender _sender;

    public RegistrationCommandHandler(ApplicationDbContext applicationDbContext, IPasswordService passwordService, ISender sender)
    {
        _applicationDbContext = applicationDbContext;
        _passwordService = passwordService;
        _sender = sender;
    }

    public async Task<User> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        _passwordService.CreatePasswordHash(request.AccountDto.Password, out byte[] passwordHash,
            out byte[] passwordSalt);

        var newAccount = new Account()
        {
            Username = request.AccountDto.Username,
            Role = request.AccountDto.Role,
            RememberMe = request.AccountDto.RememberMe
        };

        await _applicationDbContext.Accounts.AddAsync(newAccount);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

         
        switch (newAccount.Role)
        {
            case Role.Teacher:
                newAccount.UserId = await _sender.Send(new RegisterTeacherCommand()
                {
                    UserDto = request.UserDto,
                    PasswordHash = passwordHash, 
                    PasswordSalt = passwordSalt,
                    Username = newAccount.Username
                });
                break;
            case Role.Student:
                newAccount.UserId = await _sender.Send(new RegisterStudentCommand()
                {
                    UserDto = request.UserDto,
                    PasswordHash = passwordHash, 
                    PasswordSalt = passwordSalt,
                    Username = newAccount.Username
                });
                break;
        }

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return await _applicationDbContext.Users.FirstOrDefaultAsync(x=>x.Id==newAccount.UserId);
    }
}