using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            // name
            builder.Property(group => group.Name)
                .IsRequired();
            
            // creation date
            builder.Property(group => group.CreationDate)
                .IsRequired();

            // invite code
            builder.Property(group => group.InviteCode)
                .IsRequired();

            builder.HasIndex(group => group.InviteCode)
                .IsUnique();
        }
    }
}