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
    public int QuestionCount { get; set; }
    public int MaxScore { get; set; }
    public List<QuizQuestionDto> Questions { get; set; } = [];

    public void Mapping(Profile profile)
        => profile.CreateMap<Quiz, QuizDetailsVm>()
            .ForMember(d => d.QuestionCount, opt => opt.MapFrom(src => src.Questions.Count))
            .ForMember(d => d.MaxScore, opt => opt.MapFrom(src => src.Questions.Sum(q => q.Points)));
}

public class QuizQuestionDto : IMapWith<QuizQuestion>
{
    public Guid Id { get; set; }
    public string QuestionText { get; set; } = string.Empty;
    public string OptionA { get; set; } = string.Empty;
    public string OptionB { get; set; } = string.Empty;
    public string? OptionC { get; set; }
    public string? OptionD { get; set; }
    public char CorrectAnswer { get; set; }
    public byte Points { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<QuizQuestion, QuizQuestionDto>();
}