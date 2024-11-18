using Application.Guests.Dtos;

namespace Application.Guests.Requests
{
    public class UpdateGuestRequest
    {
        public GuestDto? Data;

        public int GuestId { get; set; }
    }
}
