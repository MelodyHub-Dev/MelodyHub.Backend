namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizList;

public class QuizListVm
{
    public IList<QuizListLookupDto> Quizzes { get; set; } = [];
}
