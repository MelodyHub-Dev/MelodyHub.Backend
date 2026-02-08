namespace MelodyHub.Application.CQRS.QiuzResults.Queries.GetQuizResultList;

public class QuizResultListVm
{
    public IList<QuizResultListLookupDto> QuizResults { get; set; } = [];
}
