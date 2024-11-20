using Application.Booking.Requests;
using Application.Booking.Responses;
using Application.Responses;

namespace Application.Ports
{
    public interface IBookingManager
    {
        Task<BookingResponse> CreateBooking(CreateBookingRequest request);
        Task<BookingResponse> GetBooking(int bookingId);
        Task<BookingListResponse> GetAllBooking();
        Task<BookingResponse> RemoveBooking(int bookingId);
        Task<BookingResponse> UpdateBooking(CreateBookingRequest request);
    }
}
