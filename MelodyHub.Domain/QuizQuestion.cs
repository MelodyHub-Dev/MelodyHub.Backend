namespace MelodyHub.Domain;

public class QuizQuestion
{
    public Guid Id { get; set; }
    public Guid QuizId { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public string OptionA { get; set; } = string.Empty;
    public string OptionB { get; set; } = string.Empty;
    public string? OptionC { get; set; }
    public string? OptionD { get; set; }
    public char CorrectAnswer { get; set; } // 'a', 'b', 'c', 'd'
    public string? Explanation { get; set; }
    public byte Points { get; set; } = 10;

    public Quiz Quiz { get; set; } = null!;

    public bool IsCorrectAnswer(char answer) =>
        char.ToLower(answer) == char.ToLower(CorrectAnswer);

    public string GetOption(char option)
    {
        return char.ToLower(option) switch
        {
            'a' => OptionA,
            'b' => OptionB,
            'c' => OptionC ?? string.Empty,
            'd' => OptionD ?? string.Empty,
            _ => string.Empty
        };
    }
}
