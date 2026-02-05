using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.QuizQuestions.Commands.DeleteQuizQuestion;

public class DeleteQuizQuestionCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<DeleteQuizQuestionCommand>
{
    public async Task Handle(DeleteQuizQuestionCommand request, CancellationToken cancellationToken)
    {
        var quizQuestion = await context.QuizQuestions
            .FindAsync([request.QuizQuestionId], cancellationToken)
            ?? throw new NotFoundException(nameof(QuizQuestion), request.QuizQuestionId);

        context.QuizQuestions.Remove(quizQuestion);

        await context.SaveChangesAsync(cancellationToken);
    }
}
