using MediatR;

namespace MelodyHub.Application.CQRS.QiuzResults.Commands.CreateQuizResult;

public class CreateQuizResultCommand : IRequest<Guid>
{
    public Guid UserId { get; set; }
    public Guid QuizId { get; set; }
    public int Score { get; set; }
    public int MaxScore { get; set; }
}
