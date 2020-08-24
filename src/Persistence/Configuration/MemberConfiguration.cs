using Domain.Entities.MemberEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            // composite key
            builder.HasKey(member => new {member.UserId, member.GroupId});
            
            // is admin
            builder.Property(member => member.IsAdmin)
                .IsRequired();
        }
    }
}