using Application.Dtos;

namespace Application.Room.Responses
{
    public class RoomListResponse : Response
    {
        public List<RoomDto> Data { get; set; }
    }
}