using Microsoft.AspNetCore.Mvc;

namespace Tutorit.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : Controller
{

    [HttpGet]
    public async Task<string> GetAString()
    {
        return "Hello World";
    }
}