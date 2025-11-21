using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Data.Configurations
{
    public class FlightConfig : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            // Relation one-to-many : Plane → Flights
            builder.HasOne(f => f.MyPlane)
                   .WithMany(p => p.Flights)
                   .HasForeignKey(f => f.PlaneId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relation many-to-many : Flights ↔ Passengers
            builder.HasMany(f => f.Passengers)
                   .WithMany(p => p.Flights);
        }
    }
}
