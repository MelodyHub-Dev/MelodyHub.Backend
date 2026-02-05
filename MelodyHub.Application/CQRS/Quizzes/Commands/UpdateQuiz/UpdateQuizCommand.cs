using MediatR;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Quizzes.Commands.UpdateQuiz;

public class UpdateQuizCommand : IRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
    public bool IsActive { get; set; } = true;
}
