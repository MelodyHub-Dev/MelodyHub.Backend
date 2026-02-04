using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.UserFavorites.Commands.CreateUserFavorite;

namespace MelodyHub.WebApi.Models;

public class CreateUserFavoriteDto : IMapWith<CreateUserFavoriteCommand>
{
    public Guid UserId { get; set; }
    public Guid InstrumentId { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateUserFavoriteDto, CreateUserFavoriteCommand>();
}
