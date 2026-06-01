using AutoMapper;
using MelodyHub.Application.CQRS.ArticleComments.Commands.ApproveArticleComment;
using MelodyHub.Application.CQRS.ArticleComments.Commands.CreateArticleComment;
using MelodyHub.Application.CQRS.ArticleComments.Commands.DeleteArticleComment;
using MelodyHub.Application.CQRS.ArticleComments.Commands.UpdateArticleComment;
using MelodyHub.Application.CQRS.ArticleComments.Queries.GetArticleCommentList;
using MelodyHub.Application.CQRS.ArticleComments.Queries.GetPendingArticleCommentList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("/api/article-comments")]
public class ArticleCommentController(IMapper mapper) : BaseController
{
    [HttpGet("{articleId:guid}")]
    public async Task<ActionResult<ArticleCommentListVm>> Get(Guid articleId)
    {
        var query = new GetArticleCommentListQuery
        {
            ArticleId = articleId
        };

        var articleComments = await Mediator.Send(query);

        return Ok(articleComments);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateArticleCommentDto dto)
    {
        var command = mapper.Map<CreateArticleCommentCommand>(dto);

        var commentId = await Mediator.Send(command);

        return Ok(commentId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateArticleCommentDto dto)
    {
        var command = mapper.Map<UpdateArticleCommentCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpGet("pending")]
    public async Task<ActionResult<ArticleCommentListVm>> GetPending()
    {
        var query = new GetPendingArticleCommentListQuery();
        var pendingComments = await Mediator.Send(query);

        return Ok(pendingComments);
    }

    [HttpPut("approve/{id:guid}")]
    public async Task<ActionResult> Approve(Guid id)
    {
        var command = new ApproveArticleCommentCommand { Id = id };

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteArticleCommentCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
