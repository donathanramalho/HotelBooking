using Domain.Rooms.Enums;

namespace Domain.Rooms.ValueObjects
{
    public class Price
    {
        public Price(decimal price) { } // Construtor sem parâmetros para EF Core

        public Price(decimal value, AcceptedCurrencies currency)
        {
            Value = value;
            Currency = currency;
        }

        public decimal Value { get; set; }
        public AcceptedCurrencies Currency { get; set; }
    }
}
