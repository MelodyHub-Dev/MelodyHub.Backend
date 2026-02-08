namespace MelodyHub.Application.CQRS.BlogArticles.Queries.GetBlogArticlesList;

public class BlogArticleListVm
{
    public IList<BlogArticleListLookupDto> BlogArticles { get; set; } = [];
}
