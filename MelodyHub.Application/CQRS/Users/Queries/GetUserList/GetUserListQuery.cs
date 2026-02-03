using MediatR;

namespace MelodyHub.Application.CQRS.Users.Queries.GetUserList;

public class GetUserListQuery : IRequest<UserListVm>
{
    public Guid Id { get; set; }
}
