using MediatR;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Quizzes.Commands.CreateQuiz;

public class CreateQuizCommand : IRequest<Guid>
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
    public bool IsActive { get; set; } = true;
}
