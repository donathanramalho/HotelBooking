using Domain.Rooms.ValueObjects;

namespace Domain.Rooms.Entities;
public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Level { get; set; }
    public bool IsInMaintenance { get; set; }

    public required Price Price { get; set; }

    public bool IsAvailable => IsInMaintenance || HasGuest;

    public static bool HasGuest => true;
}
