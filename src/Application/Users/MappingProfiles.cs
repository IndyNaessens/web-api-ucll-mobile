using Application.Users.Command.CreateUser;
using AutoMapper;
using Domain.Entities.UserEntity;

namespace Application.Users
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateUser
            CreateMap<CreateUserCommand, User>();
        }
    }
}