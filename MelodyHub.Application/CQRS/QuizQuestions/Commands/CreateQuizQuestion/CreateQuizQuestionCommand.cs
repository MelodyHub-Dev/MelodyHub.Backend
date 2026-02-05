using MediatR;

namespace MelodyHub.Application.CQRS.QuizQuestions.Commands.CreateQuizQuestion;

public class CreateQuizQuestionCommand : IRequest<Guid>
{
    public Guid QuizId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public string OptionA { get; set; } = string.Empty;
    public string OptionB { get; set; } = string.Empty;
    public string? OptionC { get; set; }
    public string? OptionD { get; set; }
    public char CorrectAnswer { get; set; } // 'a', 'b', 'c', 'd'
    public string? Explanation { get; set; }
    public byte Points { get; set; } = 10;
}
