using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectList;

public class UserProjectListLookupDto : IMapWith<UserProject>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ProjectStatus Status { get; set; } = ProjectStatus.Planned;
    public byte Progress { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public decimal? ActualCost { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<UserProject, UserProjectListLookupDto>();
}
