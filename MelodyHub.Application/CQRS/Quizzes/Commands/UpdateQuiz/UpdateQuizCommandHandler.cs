using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Quizzes.Commands.UpdateQuiz;

public class UpdateQuizCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateQuizCommand>
{
    public async Task Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await context.Quizzes
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Quiz), request.Id);

        quiz.Title = request.Title;
        quiz.Description = request.Description;
        quiz.Difficulty = request.Difficulty;
        quiz.IsActive = request.IsActive;

        await context.SaveChangesAsync(cancellationToken);
    }
}
