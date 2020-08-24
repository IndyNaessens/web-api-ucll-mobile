using Application.Groups.Command.CreateGroup;
using AutoMapper;
using Domain.Entities;

namespace Application.Groups
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // CreateGroupCommand
            CreateMap<CreateGroupCommand, Group>();
        }
    }
}