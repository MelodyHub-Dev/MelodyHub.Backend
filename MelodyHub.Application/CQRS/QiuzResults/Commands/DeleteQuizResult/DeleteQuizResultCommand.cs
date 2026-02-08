using MediatR;

namespace MelodyHub.Application.CQRS.QiuzResults.Commands.DeleteQuizResult;

public class DeleteQuizResultCommand : IRequest
{
    public Guid Id { get; set; }
}
