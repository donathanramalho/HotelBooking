using Application.Booking.Requests;
using Application.Booking.Responses;
using Application.Dtos;
using Application.Ports;
using Application.Responses;
using Domain.Exceptions;
using Domain.Ports;

namespace Application.Booking
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IRoomRepository _roomRepository;

        public BookingManager(IBookingRepository bookingRepository, IRoomRepository roomRepository)
        {
            _bookingRepository = bookingRepository;
            _roomRepository = roomRepository;
        }

        public async Task<BookingResponse> CreateBooking(CreateBookingRequest request)
        {
            try
            {
                if (request.Data.Start > request.Data.End)
                {
                    return new BookingResponse
                    {
                        Success = false,
                        ErrorCode = ErrorCode.INVALID_BOOKING_DATE,
                        Message = "Invalid booking date"
                    };
                }

                var inMaintanence = (await this._roomRepository.GetRoom(request.Data.RoomId)).InMaintenance;

                if (inMaintanence)
                {
                    return new BookingResponse
                    {
                        Success = false,
                        ErrorCode = ErrorCode.ROOM_IN_MAINTENANCE,
                        Message = "Room in maintenance"
                    };
                }

                var notFinishedBookings = await this._bookingRepository.GetNotFinishedBookings();

                var alreadyReserved = notFinishedBookings.Any(booking => booking.RoomId == request.Data.RoomId && booking.Start < request.Data.End && booking.End > request.Data.Start);

                if (alreadyReserved)
                {
                    return new BookingResponse
                    {
                        Success = false,
                        ErrorCode = ErrorCode.ROOM_ALREADY_BOOKED,
                        Message = "Room already booked"
                    };
                }

                var booking = BookingDto.MapToEntity(request.Data);

                var result = await this._bookingRepository.SaveBooking(booking);

                return new BookingResponse()
                {
                    Data = request.Data,
                    Success = true,
                };
            }
            catch (MissingRequiredInformationException)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.MISSING_REQUIRED_INFORMATION,
                    Message = "Missing information"
                };
            }
            catch (Exception)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.COULD_NOT_STORE_DATA,
                    Message = "Could not save data"
                };
            }
        }

        public async Task<BookingListResponse> GetAllBooking()
        {
            try
            {
                var books = await this._bookingRepository.GetAllBookings();

                var list = new List<BookingDto>();

                foreach (var book in books)
                {
                    list.Add(BookingDto.MapToDto(book));
                }

                return new BookingListResponse()
                {
                    Success = true,
                    Data = list,
                };
            }
            catch (Exception)
            {
                return new BookingListResponse()
                {
                    Success = false,
                    ErrorCode = ErrorCode.COULD_NOT_RETRIEVE_DATA,
                    Message = "There was an error when saving to DB"
                };
            }
        }

        public async Task<BookingResponse> GetBooking(int bookingId)
        {
            var book = await _bookingRepository.GetBooking(bookingId);

            if (book == null)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.NOT_FOUND,
                    Message = "Room not found"
                };
            }

            return new BookingResponse()
            {
                Data = BookingDto.MapToDto(book),
                Success = true,
            };
        }

        public async Task<BookingResponse> RemoveBooking(int bookingId)
        {
            try
            {
                var deleted = await _bookingRepository.DeleteBooking(bookingId);

                return new BookingResponse()
                {
                    Success = true,
                    Data = BookingDto.MapToDto(deleted),
                };
            }
            catch (NotFoundException)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.GUEST_NOT_FOUND
                };
            }
            catch (Exception)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.COULD_NOT_DELETE_DATA
                };
            }
        }

        public async Task<BookingResponse> UpdateBooking(CreateBookingRequest request)
        {
            try
            {
                var book = BookingDto.MapToEntity(request.Data);

                await this._bookingRepository.UpdateBooking(book);

                return new BookingResponse()
                {
                    Data = request.Data,
                    Success = true,
                };
            }
            catch (MissingRequiredInformationException)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.MISSING_REQUIRED_INFORMATION,
                    Message = "Missing information"
                };
            }
            catch (Exception)
            {
                return new BookingResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.COULD_NOT_STORE_DATA,
                    Message = "There was an error when saving to DB"
                };
            }
        }
    }
}