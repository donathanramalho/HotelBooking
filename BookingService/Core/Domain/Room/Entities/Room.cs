using Domain.Exceptions;
using Domain.Room.Exceptions;
using Domain.Room.ValueObjects;

namespace Domain.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public bool InMaintenance { get; set; }

        public Price Price { get; set; }

        public IList<Booking> Bookings { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name) || Level == null || Price.Value == null || Price.Currency == null)
            {
                throw new MissingRequiredInformationException();
            }

            if (Price.Value < 0)
            {
                throw new InvalidPriceException();
            }
        }

        public bool IsAvailable
        {
            get
            {
                if (this.InMaintenance || HasGuest)
                {
                    return false;
                }
                return true;
            }

        }

        public bool HasGuest
        {
            get
            {
                return true;
            }
        }
    }
}
