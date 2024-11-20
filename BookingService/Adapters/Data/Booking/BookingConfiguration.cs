using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {

            builder.ToTable("Bokings");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Guest)
                .WithMany(y => y.Bookings)
                .HasForeignKey(e => e.GuestId);

            builder.HasOne(x => x.Room)
                .WithMany(y => y.Bookings)
                .HasForeignKey(e => e.RoomId);
        }
    }
}