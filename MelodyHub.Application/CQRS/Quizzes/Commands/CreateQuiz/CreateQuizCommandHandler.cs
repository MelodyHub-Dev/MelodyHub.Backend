using MediatR;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Quizzes.Commands.CreateQuiz;

public class CreateQuizCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateQuizCommand, Guid>
{
    public async Task<Guid> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
    {
        var newQuiz = new Quiz
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Difficulty = request.Difficulty,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        await context.Quizzes.AddAsync(newQuiz, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return newQuiz.Id;
    }
}
