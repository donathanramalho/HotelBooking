using Application.Ports;
using Microsoft.AspNetCore.Mvc;
using Application.Bookings.Dtos;
using Application.Bookings.Requests;

namespace API.Controllers
{
    [ApiController]
    [Route("booking")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IBookingManager _bookingManager;

        public BookingController(
            ILogger<BookingController> logger,
            IBookingManager bookingManager)
        {
            _logger = logger;
            _bookingManager = bookingManager;
        }

        [NonAction]
        public IBookingManager Get_bookingManager()
        {
            return _bookingManager;
        }

        [HttpPost]
        public async Task<ActionResult<BookingDto>> Post(BookingDto booking)
        {

            var resquest = new CreateBookingRequest
            {
                Data = booking,
            };

            var res = await _bookingManager.CreateBooking(resquest);

            if (res.Success) return Created("", res.Data);

            _logger.LogError("Response with unkwn ErrorCode Returned", res);
            return BadRequest();

        }

        [HttpGet]
        public async Task<ActionResult<BookingDto>> Get()
        {
            var res = await _bookingManager.GetBookings();

            if (res.Success) return Ok(res.Data);

            return NotFound(res);
        }

        [HttpGet("{bookingId}")]
        public async Task<ActionResult<BookingDto>> GetById(int bookingId)
        {
            var res = await _bookingManager.GetBooking(bookingId);

            if (res.Success) return Created("", res.Data);

            return NotFound(res);
        }

        [HttpPut("{bookingId}")]
        public async Task<ActionResult<BookingDto>> Update(int bookingId, BookingDto booking)
        {
            var request = new UpdateBookingRequest
            {
                BookingId = bookingId,
                Data = booking
            };

            var res = await _bookingManager.UpdateBooking(request);

            if (res.Success) return Ok(res.Data);

            _logger.LogError("Failed to update booking with ID {BookingId}", bookingId);
            return BadRequest();
        }

        [HttpDelete("{bookingId}")]
        public async Task<ActionResult<BookingDto>> Delete(int bookingId)
        {
            var res = await _bookingManager.DeleteBooking(bookingId);

            if (res.Success) return NoContent();

            _logger.LogError("Failed to delete booking with ID {BookingId}", bookingId);
            return NotFound(res);
        }
    }
}
