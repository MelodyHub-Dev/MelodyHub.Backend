using MediatR;

namespace MelodyHub.Application.CQRS.QuizQuestions.Queries.GetQuizQuestionList;

public class GetQuizQuestionListQuery : IRequest<QuizQuestionListVm>
{
    public Guid QuizId { get; set; }
}