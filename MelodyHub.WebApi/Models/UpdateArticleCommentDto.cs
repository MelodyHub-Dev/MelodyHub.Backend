using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.ArticleComments.Commands.UpdateArticleComment;

namespace MelodyHub.WebApi.Models;

public class UpdateArticleCommentDto : IMapWith<UpdateArticleCommentCommand>
{
    public Guid Id { get; set; }
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
    public Guid? ParentCommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public bool IsApproved { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateArticleCommentDto, UpdateArticleCommentCommand>();
}
