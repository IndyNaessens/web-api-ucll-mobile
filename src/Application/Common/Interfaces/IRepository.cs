using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.MemberEntity;
using Domain.Entities.ShoppingTripEntity;
using Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IRepository
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ShoppingTrip> ShoppingTrips { get; set; }
        public DbSet<ShoppingTripItem> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        
        /// <summary>
        /// Check if the user is a member of the group
        /// </summary>
        public Task<bool> IsMemberOfGroupAsync(int userId, int groupId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Check if the user is a member of the group and also an administrator
        /// </summary>
        public Task<bool> IsAdminOfGroupAsync(int userId, int groupId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Check if a member created the shopping trip provided
        /// </summary>
        public Task<bool> IsCreatorOfShoppingTrip(int userId, int groupId, int shoppingTripId, CancellationToken cancellationToken);

        /// <summary>
        /// Check if a member has access to the shopping trip
        /// The member is in the same group as where the shopping trip was created in
        /// </summary>
        public Task<bool> HasAccessToShoppingTrip(int userId, int shoppingTripId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Check if a member can alter a shopping trip item
        /// The member needs to be the creator of the item to alter it
        /// </summary>
        public Task<bool> CanAlterShoppingTripItem(int userId, int groupId, int shoppingTripId, int shoppingTripItemId, CancellationToken cancellationToken);


        public Task<int> SaveChangesAsync (CancellationToken cancellationToken);
    }
}