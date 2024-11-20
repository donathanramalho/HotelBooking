namespace Application
{
    public enum ErrorCode
    {
        //Guest
        NOT_FOUND = 1,
        COULD_NOT_STORE_DATA = 2,
        INVALID_PERSON_ID = 3,
        MISSING_REQUIRED_INFORMATION = 4,
        INVALID_EMAIL = 5,
        GUEST_NOT_FOUND = 6,
        COULD_NOT_DELETE_DATA = 7,
        COULD_NOT_RETRIEVE_DATA = 8,
        //Room
        INVALID_PRICE = 9,

        //Booking
        ROOM_ALREADY_BOOKED = 10,

        ROOM_IN_MAINTENANCE = 11,

        INVALID_BOOKING_DATE = 12,

        //Payment
    }
    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ErrorCode ErrorCode { get; set; }

    }
}
