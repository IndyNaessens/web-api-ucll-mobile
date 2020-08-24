using Application.Common.Dtos;
using AutoMapper;
using Domain.Entities.ShoppingTripEntity;
using Domain.Entities.UserEntity;

namespace Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Location, LocationDto>().ReverseMap();
        }
    }
}