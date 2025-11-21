using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Data.Configurations
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
           
            builder.HasKey(r => r.ReservationId);

           
            builder.Property(r => r.ReservationDate)
                .IsRequired();

            builder.Property(r => r.SeatNumber)
                .HasMaxLength(10);

            builder.Property(r => r.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            
            builder.HasOne(r => r.Passenger)
                .WithMany(p => p.Reservations)
                .HasForeignKey(r => r.PassportNumber)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.Flight)
                .WithMany(f => f.Reservations)
                .HasForeignKey(r => r.FlightId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}