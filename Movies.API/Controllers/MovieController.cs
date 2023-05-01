using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.API.Models.DTO;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MovieController : ControllerBase
{
    private readonly MovieDbContext _movieDbContext;

    public MovieController(MovieDbContext movieDbContext)
    {
        _movieDbContext = movieDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Movies()
    {
        return Ok(await _movieDbContext.Movies.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var movie = await _movieDbContext.Movies.FirstOrDefaultAsync(f => f.Id == id);
        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> Movie([FromBody] MovieRequest request)
    {
        _movieDbContext.Movies.Add(request.ToModel());
        var saveMovie =await _movieDbContext.SaveChangesAsync();
        return Ok();

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Movie(int id, [FromBody] MovieRequest request)
    {
        var oldMovie = _movieDbContext.Movies.FirstOrDefault(f => f.Id == id);  
        if (oldMovie == null)  return NotFound(); 

        _movieDbContext.Update(request.ToModel());
        await _movieDbContext.SaveChangesAsync();
        return Ok();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Movie(int id)
    {
        var movie = _movieDbContext.Movies.FirstOrDefault(f=>f.Id == id);
        if (movie == null) return NotFound();
        _movieDbContext.Remove(movie);
        await _movieDbContext.SaveChangesAsync();
        return Ok();
    }
}