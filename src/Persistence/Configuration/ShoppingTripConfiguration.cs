using Domain.Entities.ShoppingTripEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Persistence.Configuration
{
    public class ShoppingTripConfiguration : IEntityTypeConfiguration<ShoppingTrip>
    {
        public void Configure(EntityTypeBuilder<ShoppingTrip> builder)
        {
            // name
            builder.Property(st => st.Name)
                .IsRequired();
            
            // reason
            builder.Property(st => st.Reason)
                .IsRequired();
            
            // start time
            builder.Property(st => st.StartTime)
                .IsRequired();

            // means of transport
            builder.Property(st => st.Transportation)
                .HasConversion(new EnumToStringConverter<Transportation>())
                .IsRequired();
        }
    }
}