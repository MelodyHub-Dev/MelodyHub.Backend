using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Quizzes.Commands.DeleteQuiz;

public class DeleteQuizCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteQuizCommand>
{
    public async Task Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
    {
        var quiz = await context.Quizzes
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(Quiz), request.Id);

        context.Quizzes.Remove(quiz);
        await context.SaveChangesAsync(cancellationToken);
    }
}
