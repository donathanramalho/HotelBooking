using Domain.Rooms.Entities;
using Domain.Rooms.Enums;
using Domain.Rooms.ValueObjects;

namespace Application.Dtos
{
    public class RoomDto
    {
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public bool IsInMaintenance { get; set; }
        public decimal Price { get; set; }
        public required string Currency { get; set; }

        public static Room MapToEntity(RoomDto roomDto)
        {
            try
            {
                if (!Enum.TryParse<AcceptedCurrencies>(roomDto.Currency, ignoreCase: true, out var currency))
                {
                    throw new ArgumentException($"Invalid currency value: {roomDto.Currency}");
                }

                var room = new Room
                {
                    Name = roomDto.Name,
                    Level = roomDto.Level,
                    IsInMaintenance = roomDto.IsInMaintenance,
                    Price = new Price(roomDto.Price, currency)
                };

                return room;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in MapToEntity: {ex.Message}");
                throw;
            }
        }

        public static RoomDto MapToDto(Room room)
        {
            return new RoomDto
            {
                Name = room.Name,
                Level = room.Level,
                IsInMaintenance = room.IsInMaintenance,
                Price = room.Price.Value,
                Currency = room.Price.Currency.ToString()
            };
        }
    }
}



