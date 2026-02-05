using AutoMapper;
using MelodyHub.Application.CQRS.QuizQuestions.Commands.CreateQuizQuestion;
using MelodyHub.Application.CQRS.QuizQuestions.Commands.DeleteQuizQuestion;
using MelodyHub.Application.CQRS.QuizQuestions.Commands.UpdateQuizQuestion;
using MelodyHub.Application.CQRS.QuizQuestions.Queries.GetQuizQuestionList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/quiz-questions")]
public class QuizQuestionController(IMapper mapper) : BaseController
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<QuizQuestionListVm>> Get(Guid id)
    {
        var query = new GetQuizQuestionListQuery
        {
            QuizId = id
        };

        var quizQuiestions = await Mediator.Send(query);

        return Ok(quizQuiestions);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateQuizQuestionDto dto)
    {
        var command = mapper.Map<CreateQuizQuestionCommand>(dto);

        var quizQuestionId = await Mediator.Send(command);

        return Ok(quizQuestionId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateQuizQuestionDto dto)
    {
        var command = mapper.Map<UpdateQuizQuestionCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteQuizQuestionCommand
        {
            QuizQuestionId = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
