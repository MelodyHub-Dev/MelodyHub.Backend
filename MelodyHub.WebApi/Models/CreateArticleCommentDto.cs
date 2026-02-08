using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.ArticleComments.Commands.CreateArticleComment;

namespace MelodyHub.WebApi.Models;

public class CreateArticleCommentDto : IMapWith<CreateArticleCommentCommand>
{
    public Guid ArticleId { get; set; }
    public Guid UserId { get; set; }
    public Guid? ParentCommentId { get; set; }
    public string Content { get; set; } = string.Empty;

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateArticleCommentDto, CreateArticleCommentCommand>();
}