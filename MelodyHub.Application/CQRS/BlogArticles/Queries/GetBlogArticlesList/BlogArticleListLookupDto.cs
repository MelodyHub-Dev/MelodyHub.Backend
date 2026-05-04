using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticlesList;

public class BlogArticleListLookupDto : IMapWith<BlogArticle>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Excerpt { get; set; }
    public Guid AuthorId { get; set; }
    public string? AuthorName { get; set; }
    public string? ImageUrl { get; set; }
    public int ViewsCount { get; set; }
    public bool IsPublished { get; set; } = true;
    public DateTime? PublishedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
    public bool IsNew { get; set; }
    public int CommentCount { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<BlogArticle, BlogArticleListLookupDto>()
            .ForMember(d => d.AuthorName, opt => opt.MapFrom(src => src.Author.Username));
}
