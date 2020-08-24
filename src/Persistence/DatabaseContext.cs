using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Entities.MemberEntity;
using Domain.Entities.ShoppingTripEntity;
using Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DatabaseContext : DbContext, IRepository
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ShoppingTrip> ShoppingTrips { get; set; }
        public DbSet<ShoppingTripItem> Items { get; set; }
        public DbSet<Location> Locations { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options)
        { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(DatabaseContext).Assembly);
        
        public async Task<bool> IsMemberOfGroupAsync(int userId, int groupId, CancellationToken cancellationToken)
        {
            return await Members.AnyAsync(m => m.UserId == userId && m.GroupId == groupId, cancellationToken);
        }

        public async Task<bool> IsAdminOfGroupAsync(int userId, int groupId, CancellationToken cancellationToken)
        {
            return await Members.AnyAsync(m => m.UserId == userId 
                                                && m.GroupId == groupId 
                                                && m.IsAdmin, cancellationToken);
        }

        public async Task<bool> IsCreatorOfShoppingTrip(int userId, int groupId, int shoppingTripId, CancellationToken cancellationToken)
        {
            return await ShoppingTrips.AnyAsync(s => s.MemberUserId == userId 
                                               && s.MemberGroupId == groupId 
                                               && s.Id == shoppingTripId, cancellationToken);
        }

        public async Task<bool> HasAccessToShoppingTrip(int userId, int shoppingTripId, CancellationToken cancellationToken)
        {
            return await ShoppingTrips.AnyAsync(s => s.Id == shoppingTripId &&
                                                      Members.Any(m => m.UserId == userId && m.GroupId == s.MemberGroupId), cancellationToken);
        }

        public async Task<bool> CanAlterShoppingTripItem(int userId, int groupId, int shoppingTripId,int shoppingTripItemId, CancellationToken cancellationToken)
        {
            return await Items.AnyAsync(i => i.Id == shoppingTripItemId &&
                                             i.MemberUserId == userId &&
                                             i.MemberGroupId == groupId &&
                                             i.ShoppingTripId == shoppingTripId, cancellationToken);
        }
    }
}