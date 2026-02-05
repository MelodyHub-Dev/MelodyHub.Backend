using MediatR;

namespace MelodyHub.Application.CQRS.QuizQuestions.Commands.DeleteQuizQuestion;

public class DeleteQuizQuestionCommand : IRequest
{
    public Guid QuizQuestionId { get; set; }
}
