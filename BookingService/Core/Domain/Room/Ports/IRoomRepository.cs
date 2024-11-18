using Domain.Rooms.Entities;

namespace Domain.Rooms.Ports;
public interface IRoomRepository
{
    Task<bool> IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate);
    Task<Room> Create(Room room);
    Task<IEnumerable<Room>> ListRooms(int offset, int take);
}
