using System;
using System.Collections.Generic;
using Application.Common.Dtos;
using Application.Groups.Query.GetShoppingTrips;

namespace Application.Groups.Query.GetGroup
{
    public class GroupModel
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; } 
        public Guid InviteCode { get; set; }
        public List<ShoppingTripEntryModel> ShoppingTrips { get; set; }
        public List<UserDto> Members { get; set; }
    }
}