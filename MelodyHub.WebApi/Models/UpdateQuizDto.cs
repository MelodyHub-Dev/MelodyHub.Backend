using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.Quizzes.Commands.UpdateQuiz;
using MelodyHub.Domain;

namespace MelodyHub.WebApi.Models;

public class UpdateQuizDto : IMapWith<UpdateQuizCommand>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
    public bool IsActive { get; set; } = true;

    public void Mapping(Profile profile)
        => profile.CreateMap<UpdateQuizDto, UpdateQuizCommand>();
}
