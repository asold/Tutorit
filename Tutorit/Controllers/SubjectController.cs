using Microsoft.AspNetCore.Mvc;
using Tutorit.CommandsAndQueries.Subjects.Commands;

namespace Tutorit.Controllers;

[ApiController]
public class SubjectController : TutoritControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> AddSubjectAsync([FromBody] AddSubjectCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

}