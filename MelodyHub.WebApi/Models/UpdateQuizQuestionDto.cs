using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.QuizQuestions.Commands.UpdateQuizQuestion;

namespace MelodyHub.WebApi.Models;

public class UpdateQuizQuestionDto : IMapWith<UpdateQuizQuestionCommand>
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

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateQuizQuestionDto, UpdateQuizQuestionCommand>();
}
