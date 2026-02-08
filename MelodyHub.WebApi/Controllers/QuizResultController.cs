using AutoMapper;
using MelodyHub.Application.CQRS.QiuzResults.Commands.CreateQuizResult;
using MelodyHub.Application.CQRS.QiuzResults.Commands.DeleteQuizResult;
using MelodyHub.Application.CQRS.QiuzResults.Queries.GetQuizResultList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/quiz-results")]
public class QuizResultController(IMapper mapper) : BaseController
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<QuizResultListVm>> Get(Guid id)
    {
        var query = new GetQuizResultListQuery
        {
            UserId = id
        };

        var quizResults = await Mediator.Send(query);

        return Ok(quizResults);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateQuizResultDto dto)
    {
        var command = mapper.Map<CreateQuizResultCommand>(dto);

        var quizResultId = await Mediator.Send(command);

        return Ok(quizResultId);
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteQuizResultCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}