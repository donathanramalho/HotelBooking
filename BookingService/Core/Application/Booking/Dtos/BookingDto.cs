namespace Application.Dtos
{
    public class BookingDto
    {
        public DateTime PlacedAt { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
        

        public static Domain.Entities.Booking MapToEntity(BookingDto dto)
        {
            return new Domain.Entities.Booking
            {
                PlacedAt = dto.PlacedAt,
                Start = dto.Start,
                End = dto.End,
                RoomId = dto.RoomId,
                GuestId = dto.GuestId
            };
        }

        public static BookingDto MapToDto(Domain.Entities.Booking entity)
        {
            return new BookingDto
            {
                PlacedAt = entity.PlacedAt,
                Start = entity.Start,
                End = entity.End,
                RoomId = entity.RoomId,
                GuestId = entity.GuestId
            };
        }
    }
}
