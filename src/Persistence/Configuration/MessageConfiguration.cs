using Domain.Entities.MemberEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            // text content
            builder.Property(message => message.Content)
                .IsRequired();

            // send at
            builder.Property(message => message.SendAt)
                .IsRequired();
        }
    }
}