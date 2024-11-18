using Application.Dtos;

namespace Application.Rooms.Requests
{
    public class UpdateRoomRequest
    {
        public RoomDto? Data;

        public int RoomId { get; set; }
    }
}
