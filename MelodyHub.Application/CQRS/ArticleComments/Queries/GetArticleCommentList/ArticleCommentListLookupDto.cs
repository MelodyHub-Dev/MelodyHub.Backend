using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.ArticleComments.Queries.GetArticleCommentList;

public class ArticleCommentListLookupDto : IMapWith<ArticleComment>
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
    public string Username { get; set; } = string.Empty;
    public Guid? ParentCommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsApproved { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public void Mapping(Profile profile)
        => profile.CreateMap<ArticleComment, ArticleCommentListLookupDto>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username));
}
