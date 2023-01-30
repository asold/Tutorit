using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tutorit.CommandsAndQueries.Registration.Commands;
using Tutorit.CommandsAndQueries.Users.Commands.UserSubjects;
using Tutorit.Models;

namespace Tutorit.Controllers;

[ApiController]
public class UserController : TutoritControllerBase
{
    [HttpPost]
    [Route("registration")]
    [AllowAnonymous]
    public async Task<ActionResult<User>> RegisterNewUserAsync([FromBody] RegistrationCommand command)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(await Mediator.Send(command));
    }

    [HttpPost]
    [Route("subject")]
    [AllowAnonymous]
    public async Task<ActionResult> ChooseSubjectForUser([FromBody] ChooseSubjectByUserCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}