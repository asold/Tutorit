using Microsoft.AspNetCore.Mvc;
using Tutorit.CommandsAndQueries.Teachers.Commands.EditTeacherInfo;

namespace Tutorit.Controllers;

[ApiController]
public class TeacherController : TutoritControllerBase
{

    [HttpPut]
    public async Task<ActionResult<Guid>> UpdateTeacherCommand([FromBody] EditTeacherInfoCommand command)
    {
        return  Ok( await Mediator.Send(command));
    }
}