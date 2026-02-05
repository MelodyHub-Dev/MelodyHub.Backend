using MediatR;
using MelodyHub.Application.Common.Exceptions;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace MelodyHub.Application.CQRS.QuizQuestions.Commands.UpdateQuizQuestion;

public class UpdateQuizQuestionCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<UpdateQuizQuestionCommand>
{
    public async Task Handle(UpdateQuizQuestionCommand request, CancellationToken cancellationToken)
    {
        var isQuizExist = await context.Quizzes
            .AnyAsync(x => x.Id == request.QuizId, cancellationToken);

        if (!isQuizExist)
        {
            throw new NotFoundException(nameof(Quiz), request.QuizId);
        }

        var quizQuestion = await context.QuizQuestions
            .FindAsync([request.Id], cancellationToken)
            ?? throw new NotFoundException(nameof(QuizQuestion), request.Id);

        quizQuestion.QuestionText = request.QuestionText;
        quizQuestion.OptionA = request.OptionA;
        quizQuestion.OptionB = request.OptionB;
        quizQuestion.OptionC = request.OptionC;
        quizQuestion.OptionD = request.OptionD;
        quizQuestion.CorrectAnswer = request.CorrectAnswer;
        quizQuestion.Explanation = request.Explanation;
        quizQuestion.Points = request.Points;

        await context.SaveChangesAsync(cancellationToken);
    }
}