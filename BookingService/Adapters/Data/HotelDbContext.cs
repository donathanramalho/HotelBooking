using Data.Guests;
using Data.Rooms;
using Domain.Bookings.Entities;
using Domain.Guests.Entities;
using Domain.Rooms.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Booking> Bokings { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public object Bookings { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuestConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
        }

    }
}
