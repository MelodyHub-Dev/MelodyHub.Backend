using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;

namespace MelodyHub.Application.CQRS.QiuzResults.Queries.GetQuizResultList;

public class QuizResultListLookupDto : IMapWith<QuizResult>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid QuizId { get; set; }
    public int Score { get; set; }
    public int MaxScore { get; set; }
    public DateTime CompletedAt { get; set; } = DateTime.Now;
    public double Percentage => MaxScore > 0 ? (double)Score / MaxScore * 100 : 0;
    public bool Passed => Percentage >= 70;

    public void Mapping(Profile profile)
        => profile.CreateMap<QuizResult, QuizResultListLookupDto>();
}
