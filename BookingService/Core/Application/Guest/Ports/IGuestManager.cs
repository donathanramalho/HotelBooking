using Application.Guests.Requests;
using Application.Responses;

namespace Application.Ports
{
    public interface IGuestManager
    {
        Task<GuestResponse> CreateGuest(CreateGuestRequest request);
        Task<BookingResponse> GetGuests();
        Task<GuestResponse> GetGuest(int guestId);
        Task<BookingResponse> DeleteGuest(int GuestId);
        Task<BookingResponse> UpdateGuest(UpdateGuestRequest request);
    }
}
