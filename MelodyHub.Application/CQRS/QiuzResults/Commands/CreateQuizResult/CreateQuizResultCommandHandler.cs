using MediatR;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.QiuzResults.Commands.CreateQuizResult;

public class CreateQuizResultCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateQuizResultCommand, Guid>
{
    public async Task<Guid> Handle(CreateQuizResultCommand request, CancellationToken cancellationToken)
    {
        var newQuizResult = new QuizResult
        {
            Id = Guid.NewGuid(),
            QuizId = request.QuizId,
            UserId = request.UserId,
            Score = request.Score,
            MaxScore = request.MaxScore,
            CompletedAt = DateTime.UtcNow,
        };

        await context.QuizResults.AddAsync(newQuizResult, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newQuizResult.Id;
    }
}
