using Application.ShoppingTrips.Command.CreateShoppingTrip;
using Application.ShoppingTrips.Command.Items.AddItem;
using AutoMapper;
using Domain.Entities.ShoppingTripEntity;

namespace Application.ShoppingTrips
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateShoppingTripCommand, ShoppingTrip>();
            CreateMap<AddItemCommand, ShoppingTripItem>()
                .ForMember(item => item.MemberUserId, x => x.MapFrom(command => command.UserId))
                .ForMember(item => item.MemberGroupId, x => x.MapFrom(command => command.GroupId))
                .ForMember(item => item.Name, x => x.MapFrom(command => command.ShoppingTripItem.Name))
                .ForMember(item => item.Amount, x => x.MapFrom(command => command.ShoppingTripItem.Amount))
                .ForMember(item => item.IsFresh, x => x.MapFrom(command => command.ShoppingTripItem.IsFresh))
                .ForMember(item => item.Price, x => x.MapFrom(command => command.ShoppingTripItem.Price))
                .ForMember(item => item.ImageUrl, x => x.MapFrom(command => command.ShoppingTripItem.ImageUrl));

        }
    }
}