using AutoMapper;
using MelodyHub.Application.Common.Mappings;
using MelodyHub.Application.CQRS.Users.Commands.CreateUser;
using MelodyHub.Domain.Enums;

namespace MelodyHub.WebApi.Models;

public class CreateUserDto : IMapWith<CreateUserCommand>
{
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.User;

    public void Mapping(Profile profile)
        => profile.CreateMap<CreateUserDto,  CreateUserCommand>();
}
