using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.BlogArticles.Commands.UpdateBlogArticle;

namespace MelodyHub.WebApi.Models;

public class UpdateBlogArticleDto : IMapWith<UpdateBlogArticleCommand>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public string? ImageUrl { get; set; }
    public int ViewsCount { get; set; }
    public bool IsPublished { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateBlogArticleDto, UpdateBlogArticleCommand>();
}
