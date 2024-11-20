
namespace Domain.Ports
{
    public interface IGuestRepository
    {
        Task<Entities.Guest> Get(int id);
        Task<List<Entities.Guest>> GetAll();
        Task<int> Create(Entities.Guest guest);
        Task<Entities.Guest> Update(Entities.Guest guest);
        Task<Entities.Guest> Delete(int id);
    }
}
