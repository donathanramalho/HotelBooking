using Application.Bookings.Dtos;

namespace Application.Bookings.Requests
{
    public class UpdateBookingRequest
    {
        public BookingDto? Data;

        public int BookingId { get; set; }
    }
}
