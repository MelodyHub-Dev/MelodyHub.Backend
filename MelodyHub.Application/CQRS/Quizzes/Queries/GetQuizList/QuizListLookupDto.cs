using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.Quizzes.Queries.GetQuizList;

public class QuizListLookupDto : IMapWith<Quiz>
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public QuizDifficulty Difficulty { get; set; } = QuizDifficulty.Medium;
    public bool IsActive { get; set; }
    public int QuestionCount { get; set; }
    public int MaxScore { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<Quiz, QuizListLookupDto>()
            .ForMember(d => d.QuestionCount, opt => opt.MapFrom(src => src.Questions.Count))
            .ForMember(d => d.MaxScore, opt => opt.MapFrom(src => src.Questions.Sum(q => q.Points)));
}
