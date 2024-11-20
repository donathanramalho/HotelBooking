using Application.Dtos;
using Application.Room.Requests;
using Application.Room.Responses;

namespace Application.Ports
{
    public interface IRoomManager
    {
        public Task<RoomResponse> CreateRoom(CreateRoomRequest request);
        public Task<RoomResponse> GetRoom(int id);
        public Task<RoomListResponse> GetAllRooms();
        public Task<RoomResponse> UpdateRoom(CreateRoomRequest request);
        public Task<RoomResponse> RemoveRoom(int id);
    }
}
