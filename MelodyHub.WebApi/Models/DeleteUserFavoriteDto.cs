using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.UserFavorites.Commands.DeleteUserFavorite;

namespace MelodyHub.WebApi.Models;

public class DeleteUserFavoriteDto : IMapWith<DeleteUserFavoriteCommand>
{
    public Guid UserId { get; set; }
    public Guid InstrumentId { get; set; }

    public void Mapping(Profile profile)
        => profile.CreateMap<DeleteUserFavoriteDto, DeleteUserFavoriteCommand>();
}
