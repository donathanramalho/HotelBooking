using Domain.Guests.Entities;
using Domain.Guests.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Guests
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

        public Task<Guest?> Get(int Id)
        {
            return _hotelDbContext.Guests?.Where(g => g.Id == Id).FirstOrDefaultAsync();
        }

        Task<Guest> IGuestRepository.Create(Guest guest)
        {
            throw new NotImplementedException();
        }

        Task<Guest> IGuestRepository.Get(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
