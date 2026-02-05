namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;

public class UserProjectListVm
{
    public IList<UserProjectListLookupDto> UserProjects { get; set; } = [];
}