using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.QiuzResults.Commands.CreateQuizResult;
using MelodyHub.Application.CQRS.Quizzes.Commands.CreateQuiz;

namespace MelodyHub.WebApi.Models;

public class CreateQuizResultDto : IMapWith<CreateQuizResultCommand>
{
    public Guid UserId { get; set; }
    public Guid QuizId { get; set; }
    public int Score { get; set; }
    public int MaxScore { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateQuizResultDto, CreateQuizResultCommand>();
}
