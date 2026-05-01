using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// TODO: Adjust namespace
namespace Macrolith.Presentation.Controllers;

[ApiController]
[Route("api/home")]
public class HomeController(IMemoryCache memoryCache) : ControllerBase
{
    private readonly IMemoryCache _cache = memoryCache;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Message> Index([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest();

        string cacheKey = $"message_{name.ToLowerInvariant()}";
        Message? message = _cache.GetOrCreate(cacheKey, entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(3);
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);

            return new Message
            (
                Greet: $"Hello, {name}!",
                Description: "Welcome to the API"
            );
        });

        return Ok(message);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Message dto)
    {
        if (ModelState.IsValid == false) return ValidationProblem(ModelState);

        // Some logic with the dto

        return Ok();
    }

    public record Message(string Greet, string Description);
}
