using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.UserProjects.Queries.GetUserProjectDetails;

namespace MelodyHub.WebApi.Models;

public class GetUserProjectDetailsDto : IMapWith<GetUserProjectDetailsQuery>
{
    public Guid UserProjectId { get; set; }
    public Guid UserId { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<GetUserProjectDetailsDto, GetUserProjectDetailsQuery>();
}
