using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Tutorit.Controllers;

[ApiController]
[Route("tutorit/[controller]")]
// [ServiceFilter(typeof())]
public class TutoritControllerBase : Controller
{
    private ISender _mediator = null!;
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (!ModelState.IsValid && context?.Result?.GetType() == typeof(BadRequestObjectResult))
        {
            BadRequestObjectResult result = (BadRequestObjectResult) context.Result;
            object? value = result.Value;
            if (value != null)
            {
                context.Result =
                    new BadRequestObjectResult(((ValidationProblemDetails) value).Errors);
                context.ExceptionHandled = true;
            }
        }

        if (context != null)
        {
            base.OnActionExecuted(context);
        }
    }
}