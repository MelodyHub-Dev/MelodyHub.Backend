using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.BlogArticles.Commands.CreateBlogArticle;

namespace MelodyHub.WebApi.Models;

public class CreateBlogArticleDto : IMapWith<CreateBlogArticleCommand>
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public Guid AuthorId { get; set; }
    public string? ImageUrl { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateBlogArticleDto, CreateBlogArticleCommand>();
}