using Domain.Guests.Entities;

namespace Domain.Guests.Ports;
public interface IGuestRepository
{
    Task<Guest?> Get(int Id);
    Task<Guest> Create(Guest guest);

}