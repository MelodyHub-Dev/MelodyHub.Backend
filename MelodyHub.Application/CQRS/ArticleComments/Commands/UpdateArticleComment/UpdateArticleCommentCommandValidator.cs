using FluentValidation;

namespace MelodyHub.Application.CQRS.ArticleComments.Commands.UpdateArticleComment;

public class UpdateArticleCommentCommandValidator
    : AbstractValidator<UpdateArticleCommentCommand>
{
    public UpdateArticleCommentCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEqual(Guid.Empty)
           .WithMessage("Comment Id must not be empty");

        RuleFor(x => x.ArticleId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Article ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid article ID");

        RuleFor(x => x.UserId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("User ID is required")
            .NotEqual(Guid.Empty).WithMessage("Invalid user ID")
            .NotEqual(x => x.ArticleId).WithMessage("User ID cannot be the same as Article ID");

        RuleFor(x => x.ParentCommentId)
            .NotEqual(Guid.Empty).WithMessage("Invalid parent comment ID");

        RuleFor(x => x.Content)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Comment content is required")
            .MinimumLength(5).WithMessage("Comment must be at least 5 characters long")
            .MaximumLength(1000).WithMessage("Comment must not exceed 1000 characters")
            .Must(content => !content.All(char.IsWhiteSpace))
            .WithMessage("Comment cannot consist only of whitespace")
            .Must(content => !content.Contains("<script>", StringComparison.OrdinalIgnoreCase))
            .WithMessage("Comment contains potentially dangerous content")
            .Must(content => content.Split('.').Length <= 10)
            .WithMessage("Comment is too verbose (max 10 sentences)")
            .When(x => x.Content.Length > 100);

        RuleFor(x => x.IsApproved)
            .NotEmpty().WithMessage("IsApproved field is required");
    }
}