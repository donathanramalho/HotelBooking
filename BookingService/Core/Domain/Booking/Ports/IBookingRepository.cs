namespace Domain.Ports
{
    public interface IBookingRepository
    {
        public Task<Entities.Booking> GetBooking(int bookingId);
        public Task<List<Entities.Booking>> GetNotFinishedBookings();
        public Task<List<Entities.Booking>> GetAllBookings();
        public Task<Entities.Booking> CreateBooking(Entities.Booking booking);
        public Task<Entities.Booking> UpdateBooking(Entities.Booking booking);
        public Task<Entities.Booking> SaveBooking(Entities.Booking booking);
        public Task<Entities.Booking> DeleteBooking(int bookingId);
    }
}
