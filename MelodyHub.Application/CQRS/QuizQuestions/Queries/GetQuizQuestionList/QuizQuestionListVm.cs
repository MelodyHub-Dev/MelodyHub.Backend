namespace MelodyHub.Application.CQRS.QuizQuestions.Queries.GetQuizQuestionList;

public class QuizQuestionListVm
{
    public IList<QuizQuestionListLookupDto> QuizQuestions { get; set; } = [];
}
