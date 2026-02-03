namespace MelodyHub.Application.CQRS.Users.Queries.GetUserList;

public class UserListVm
{
    public IList<UserListLookupDto> Users { get; set; } = [];
}
