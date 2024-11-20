using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class GuestRepository : IGuestRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public GuestRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;

        }
        public async Task<int> Create(Guest guest)
        {
            _hotelDbContext.Guests.Add(guest);

            await _hotelDbContext.SaveChangesAsync();

            return guest.Id;
        }

        public Task<Guest> Get(int id)
        {
            return _hotelDbContext.Guests.Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public Task<List<Guest>> GetAll()
        {
            return _hotelDbContext.Guests.ToListAsync();
        }

        public async Task<Guest> Update(Guest guest)
        {
            _hotelDbContext.Guests.Update(guest);

            await _hotelDbContext.SaveChangesAsync();

            return guest;
        }

        public async Task<Guest> Delete(int id)
        {
            var guest = _hotelDbContext.Guests.FirstOrDefault(x => x.Id == id);

            this._hotelDbContext.Remove(guest);
            await _hotelDbContext.SaveChangesAsync();
            return guest;
        }
    }
}
