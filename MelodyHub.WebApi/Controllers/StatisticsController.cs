using MelodyHub.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/statistics")]
public class StatisticsController : BaseController
{
    private readonly IMelodyHubDbContext _context;

    public StatisticsController(IMelodyHubDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<StatisticsDto>> Get()
    {
        var stats = new StatisticsDto
        {
            Users = await _context.Users.CountAsync(),
            Articles = await _context.BlogArticles.CountAsync(),
            Projects = await _context.UserProjects.CountAsync(),
            Instruments = await _context.Instruments.CountAsync(),
            Instructions = await _context.Blueprints.CountAsync()
        };

        return Ok(stats);
    }
}

public class StatisticsDto
{
    public int Users { get; set; }
    public int Articles { get; set; }
    public int Projects { get; set; }
    public int Instruments { get; set; }
    public int Instructions { get; set; }
}