using MediatR;

namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizDetails;

public class GetQuizDetailsQuery : IRequest<QuizDetailsVm>
{
    public Guid Id { get; set; }
}
