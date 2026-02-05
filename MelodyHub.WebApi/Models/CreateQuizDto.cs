using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.Quizzes.Commands.CreateQuiz;
using MelodyHub.Domain;

namespace MelodyHub.WebApi.Models;

public class CreateQuizDto : IMapWith<CreateQuizCommand>
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
    public bool IsActive { get; set; } = true;

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateQuizDto, CreateQuizCommand>();
}
