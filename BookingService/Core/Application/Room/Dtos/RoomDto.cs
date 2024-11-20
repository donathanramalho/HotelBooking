using Domain.Room.Enums;

namespace Application.Dtos
{
    public class RoomDto
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }
        public decimal PriceValue { get; set; }
        public AcceptedCurrencies Currency { get; set; }

        public static Domain.Entities.Room MapToEntity(RoomDto roomDto)
        {
            return new Domain.Entities.Room
            {
                Name = roomDto.Name,
                Level = roomDto.Level,
                InMaintenance = roomDto.InMaintenance,
                Price = new Domain.Room.ValueObjects.Price
                {
                    Value = roomDto.PriceValue,
                    Currency = roomDto.Currency
                }
            };
        }

        public static RoomDto MapToDto(Domain.Entities.Room room)
        {
            return new RoomDto
            {
                Name = room.Name,
                Level = room.Level,
                InMaintenance = room.InMaintenance,
                PriceValue = room.Price.Value,
                Currency = room.Price.Currency
            };
        }
    }


}
