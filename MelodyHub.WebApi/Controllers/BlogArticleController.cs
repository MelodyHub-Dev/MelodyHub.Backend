using AutoMapper;
using MelodyHub.Application.CQRS.BlogArticles.Commands.CreateBlogArticle;
using MelodyHub.Application.CQRS.BlogArticles.Commands.DeleteBlogArticle;
using MelodyHub.Application.CQRS.BlogArticles.Commands.UpdateBlogArticle;
using MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticleDetails;
using MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticlesList;
using MelodyHub.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MelodyHub.WebApi.Controllers;

[Route("api/blog-articles")]
public class BlogArticleController(IMapper mapper) : BaseController
{
    [HttpGet("details/{id:guid}")]
    public async Task<ActionResult<BlogArticleDetailsVm>> GetDetails(Guid id)
    {
        var query = new GetBlogArticleDetailsQuery
        {
            BlogArticleId = id
        };

        var blogArticle = await Mediator.Send(query);

        return Ok(blogArticle);
    }

    [HttpGet("{authorId:guid}")]
    public async Task<ActionResult<BlogArticleListVm>> Get(Guid authorId)
    {
        var query = new GetBlogArticleListQuery
        {
            AuthorId = authorId
        };

        var blogArticles = await Mediator.Send(query);

        return Ok(blogArticles);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateBlogArticleDto dto)
    {
        var command = mapper.Map<CreateBlogArticleCommand>(dto);

        var blogArticleId = await Mediator.Send(command);

        return Ok(blogArticleId);
    }

    [HttpPut("update")]
    public async Task<ActionResult> Update([FromBody] UpdateBlogArticleDto dto)
    {
        var command = mapper.Map<UpdateBlogArticleCommand>(dto);

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteBlogArticleCommand
        {
            Id = id
        };

        await Mediator.Send(command);

        return NoContent();
    }
}
