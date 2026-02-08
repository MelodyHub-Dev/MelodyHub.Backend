using MediatR;

namespace MelodyHub.Application.CQRS.QiuzResults.Queries.GetQuizResultList;

public class GetQuizResultListQuery : IRequest<QuizResultListVm>
{
    public Guid UserId { get; set; }
}
