using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizList;

public class QuizListLookupDto : IMapWith<Quiz>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
    public bool IsActive { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<Quiz, QuizListLookupDto>();
}
