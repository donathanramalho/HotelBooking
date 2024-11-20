namespace Domain.Ports
{
    public interface IRoomRepository
    {
        public Task<Entities.Room> GetRoom(int roomId);
        public Task<List<Entities.Room>> GetAllRooms();
        public Task<Entities.Room> CreateRoom(Entities.Room room);
        public Task<Entities.Room> UpdateRoom(Entities.Room room);
        public Task<Entities.Room> SaveRoom(Entities.Room room);
        public Task<Entities.Room> DeleteRoom(int roomId);
    }
}
