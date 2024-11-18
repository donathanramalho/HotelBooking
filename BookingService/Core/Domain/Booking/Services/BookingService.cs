using Domain.Bookings.Entities;
using Domain.Bookings.Ports;

public class BookingService
{
    private readonly IBookingRepository bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        this.bookingRepository = bookingRepository;
    }

    public async Task<Booking> CreateBooking(Booking booking)
    {
        return await bookingRepository.Create(booking);
    }

}