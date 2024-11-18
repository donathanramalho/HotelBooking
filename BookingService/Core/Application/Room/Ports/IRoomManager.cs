using Application.Rooms.Requests;
using Application.Responses;

namespace Application.Ports
{
    public interface IRoomManager
    {
        Task<RoomResponse> CreateRoom(CreateRoomRequest request);
        Task<RoomResponse> GetRooms();
        Task<RoomResponse> GetRoom(int roomId);
        Task<RoomResponse> DeleteRoom(int roomId);
        Task<RoomResponse> UpdateRoom(UpdateRoomRequest request);
    }
}
