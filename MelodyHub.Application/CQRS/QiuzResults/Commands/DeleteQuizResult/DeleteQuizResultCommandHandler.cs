using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.QiuzResults.Commands.DeleteQuizResult;

public class DeleteQuizResultCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteQuizResultCommand>
{
    public async Task Handle(DeleteQuizResultCommand request, CancellationToken cancellationToken)
    {
        var quizResult = await context.QuizResults
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(QuizResult), request.Id);

        context.QuizResults.Remove(quizResult);

        await context.SaveChangesAsync(cancellationToken);
    }
}
