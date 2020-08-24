using Domain.Entities.ShoppingTripEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            // key
            builder.HasKey(location => location.ShoppingTripId);

            // placeid google maps
            builder.Property(location => location.PlaceId)
                .IsRequired();
            
            // name of store
            builder.Property(location => location.StoreName)
                .IsRequired();

            // address formatted
            builder.Property(location => location.FormattedAddress)
                .IsRequired();

            // store rating
            builder.Property(location => location.Rating)
                .IsRequired();
        }
    }
}