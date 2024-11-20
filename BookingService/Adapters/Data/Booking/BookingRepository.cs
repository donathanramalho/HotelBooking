using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public BookingRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            _hotelDbContext.Bookings.Add(booking);

            await _hotelDbContext.SaveChangesAsync();

            return booking;
        }

        public async Task<Booking> DeleteBooking(int bookingId)
        {
            var booking = _hotelDbContext.Bookings.FirstOrDefault(x => x.Id == bookingId);

            this._hotelDbContext.Remove(booking);
            await _hotelDbContext.SaveChangesAsync();
            return booking;
        }

        public Task<List<Booking>> GetAllBookings()
        {
            return _hotelDbContext.Bookings.ToListAsync();
        }

        public Task<Booking> GetBooking(int bookingId)
        {
            return _hotelDbContext.Bookings.Where(b => b.Id == bookingId).FirstOrDefaultAsync();
        }

        public Task<List<Booking>> GetNotFinishedBookings()
        {
            return _hotelDbContext.Bookings.Where(b => b.Status < Domain.Enums.Status.Finished).ToListAsync();
        }

        public Task<Booking> SaveBooking(Booking booking)
        {
            if (booking.Id == 0)
            {
                return CreateBooking(booking);
            }
            else
            {
                return UpdateBooking(booking);
            }
        }

        public async Task<Booking> UpdateBooking(Booking booking)
        {
            _hotelDbContext.Bookings.Update(booking);

            await _hotelDbContext.SaveChangesAsync();

            return booking;
        }
    }
}