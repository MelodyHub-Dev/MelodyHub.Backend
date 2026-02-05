using MediatR;
using MelodyHub.Application.Interfaces;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.QuizQuestions.Commands.CreateQuizQuestion;

public class CreateQuizQuestionCommandHandler(IMelodyHubDbContext context)
    : IRequestHandler<CreateQuizQuestionCommand, Guid>
{
    public async Task<Guid> Handle(CreateQuizQuestionCommand request, CancellationToken cancellationToken)
    {
        var newQuizQuestion = new QuizQuestion
        {
            Id = Guid.NewGuid(),
            QuizId = request.QuizId,
            QuestionText = request.QuestionText,
            OptionA = request.OptionA,
            OptionB = request.OptionB,
            OptionC = request.OptionC,
            OptionD = request.OptionD,
            CorrectAnswer = request.CorrectAnswer,
            Explanation = request.Explanation,
            Points = request.Points,
        };

        await context.QuizQuestions.AddAsync(newQuizQuestion, cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return newQuizQuestion.Id;
    }
}
