using Application.Bookings.Requests;
using Application.Responses;

namespace Application.Ports
{
    public interface IBookingManager
    {
        Task<BookingResponse> CreateBooking(CreateBookingRequest request);
        Task<BookingResponse> GetBookings();
        Task<BookingResponse> GetBooking(int bookingId);
        Task<BookingResponse> DeleteBooking(int bookingId);
        Task<BookingResponse> UpdateBooking(UpdateBookingRequest request);
    }
}
