namespace MelodyHub.Application.CQRS.ArticleComments.Queries.GetArticleCommentList;

public class ArticleCommentListVm
{
    public IList<ArticleCommentListLookupDto> Comments { get; set; } = [];
}
