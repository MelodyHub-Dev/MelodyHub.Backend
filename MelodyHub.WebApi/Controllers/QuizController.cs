using AutoMapper;
using MelodyHub.Application.CQRS.Quizzes.Commands.CreateQuiz;
using MelodyHub.Application.CQRS.Quizzes.Commands.DeleteQuiz;
using MelodyHub.Application.CQRS.Quizzes.Commands.UpdateQuiz;
using MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizDetails;
using MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/quizzes")]
public class QuizController(IMapper mapper) : BaseController
{
    [HttpGet]
    public async Task<ActionResult<QuizListVm>> Get()
    {
        var query = new GetQuizListQuery();

        var quizzes = await Mediator.Send(query);

        return Ok(quizzes);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<QuizDetailsVm>> Get(Guid id)
    {
        var query = new GetQuizDetailsQuery
        {
            Id = id
        };

        var quiz = await Mediator.Send(query);

        return Ok(quiz);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateQuizDto dto)
    {
        var command = mapper.Map<CreateQuizCommand>(dto);

        var quizId = await Mediator.Send(command);

        return Ok(quizId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateQuizDto dto)
    {
        var command = mapper.Map<UpdateQuizCommand>(dto);

        await Mediator.Send(command);

        return Ok(dto);
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteQuizCommand 
        {
            Id = id 
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
