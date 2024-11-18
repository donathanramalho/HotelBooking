using Domain.Bookings.Entities;

namespace Domain.Bookings.Ports;

public interface IBookingRepository
{
    Task<Booking> Create(Booking booking);
    Task<Booking> Get(int bookingId);
    Task<IEnumerable<Booking>> ListBookings(int offset, int take);
    Task<IEnumerable<Booking>> ListBookingsByRoom(int roomId, int offset, int take);

    Task<IEnumerable<Booking>> ListBookingsByGuest(int guestId, int offset, int take);
}

