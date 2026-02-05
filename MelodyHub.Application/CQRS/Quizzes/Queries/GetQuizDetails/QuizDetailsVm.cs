using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizDetails;

public class QuizDetailsVm : IMapWith<Quiz>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public void Mapping(Profile profile)
        => profile.CreateMap<Quiz, QuizDetailsVm>();
}