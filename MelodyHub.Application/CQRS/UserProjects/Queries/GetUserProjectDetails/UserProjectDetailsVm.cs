using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Domain;
using MelodyHub.Domain.Enums;

namespace MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectDetails;

public class UserProjectDetailsVm : IMapWith<UserProject>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
    public Guid InstrumentId { get; set; }
    public string InstrumentName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ProjectStatus Status { get; set; } = ProjectStatus.Planned;
    public byte Progress { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? FinishDate { get; set; }
    public decimal? ActualCost { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    public bool IsCompleted => Status == ProjectStatus.Completed;
    public string? Duration => StartDate.HasValue && FinishDate.HasValue
        ? $"{(FinishDate.Value.DayNumber - StartDate.Value.DayNumber)} дней"
        : null;
    
    public void Mapping(Profile profile)
        => profile.CreateMap<UserProject, UserProjectDetailsVm>();
}
