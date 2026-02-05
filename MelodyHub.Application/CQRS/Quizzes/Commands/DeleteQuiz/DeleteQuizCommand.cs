using MediatR;

namespace MelodyHub.Application.CQRS.Quizzes.Commands.DeleteQuiz;

public class DeleteQuizCommand : IRequest
{
    public Guid Id { get; set; }
}
