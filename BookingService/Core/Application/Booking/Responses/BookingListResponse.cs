using Application.Dtos;

namespace Application.Booking.Responses
{
    public class BookingListResponse : Response
    {
        public List<BookingDto> Data;
    }
}