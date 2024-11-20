using Domain.Exceptions;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Room
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Room> GetRoom(int roomId)
        {
            return await _context.Rooms.Where(x => x.Id == roomId).FirstOrDefaultAsync();
        }

        public async Task<List<Domain.Entities.Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Domain.Entities.Room> CreateRoom(Domain.Entities.Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Domain.Entities.Room> UpdateRoom(Domain.Entities.Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Domain.Entities.Room> SaveRoom(Domain.Entities.Room room)
        {
            room.Validate();

            if (room.Id == 0)
            {
                return await this.CreateRoom(room);
            }
            else
            {
                return await this.UpdateRoom(room);
            }
        }

        public async Task<Domain.Entities.Room> DeleteRoom(int roomId)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == roomId);
            if (room == null)
            {
                throw new NotFoundException();
            }
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return room;
        }
    }
}