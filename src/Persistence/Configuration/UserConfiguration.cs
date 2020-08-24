using Domain.Entities.UserEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // username
            builder.Property(user => user.UserName)
                .IsRequired();

            // email
            builder.Property(user => user.Email)
                .IsRequired();

            // password
            builder.Property(user => user.Password)
                .IsRequired();

            // status
            builder.Property(user => user.Status)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<Status>());

            // indexes and unique constraints
            builder.HasIndex(user => new {user.UserName, user.Email}).IsUnique();
        }
    }
}