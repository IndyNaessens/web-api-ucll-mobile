using Domain.Entities.ShoppingTripEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ShoppingTripItemConfiguration : IEntityTypeConfiguration<ShoppingTripItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingTripItem> builder)
        {
            // name
            builder.Property(sti => sti.Name)
                .IsRequired();

            // amount
            builder.Property(sti => sti.Amount)
                .IsRequired();

            // fresh
            builder.Property(sti => sti.IsFresh)
                .IsRequired();
        }
    }
}