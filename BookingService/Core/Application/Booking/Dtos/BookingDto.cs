

using Domain.Bookings.Entities;

namespace Application.Bookings.Dtos;

public class BookingDto
{
    public int Id { get; set; }
    public DateTime PlacedAt { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int RoomID { get; set; }

    public int GuestId { get; set; }

    public int StatusId { get; set; }

    internal static BookingDto MapToDto(Booking booking)
    {
        throw new NotImplementedException();
    }

    internal static Domain.Bookings.Entities.Booking MapToEntity(BookingDto? data)
    {
        throw new NotImplementedException();
    }
}

