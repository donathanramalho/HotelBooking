using Application.Guest.Requests;
using Application.Guest.Responses;
using Application.Responses;

namespace Application.Ports
{
    public interface IGuestManager
    {
        Task<GuestResponse> CreateGuest(CreateGuestRequest request);
        Task<GuestResponse> GetGuest(int guestId);
        Task<GuestListResponse> GetAll();
        Task<GuestResponse> RemoveGuest(int guestId);
        Task<GuestResponse> UpdateGuest(UpdateGuestRequest request);
    }
}
