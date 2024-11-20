using Application.Booking;
using Application.Booking.Requests;
using Application.Dtos;
using Application.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost]
        public async Task<ActionResult<BookingDto>> Post(BookingDto guest)
        {
            var resquest = new CreateBookingRequest
            {
                Data = guest,
            };

            var res = await _bookingManager.CreateBooking(resquest);

            if (res.Success) return Created("", res.Data);

            return BadRequest(res);
        }

        [HttpGet]
        public async Task<ActionResult<BookingDto>> Get(int guestId)
        {
            var res = await _bookingManager.GetBooking(guestId);

            if (res.Success) return Created("", res.Data);

            return NotFound(res);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var res = await _bookingManager.GetAllBooking();

            if (res.Success) return Ok(res.Data);

            return BadRequest(res);
        }

        [HttpDelete]
        public async Task<ActionResult<BookingDto>> Delete(int bookingId)
        {
            var res = await _bookingManager.RemoveBooking(bookingId);

            if (res.Success) return Ok(res.Data);

            if (res.ErrorCode == Application.ErrorCode.GUEST_NOT_FOUND)
            {
                return NotFound(res);
            }
            else if (res.ErrorCode == Application.ErrorCode.COULD_NOT_DELETE_DATA)
            {
                return BadRequest(res);
            }

            _logger.LogError("Response with unknown ErrorCode Returned");
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult<BookingDto>> Update(BookingDto dto)
        {
            var request = new CreateBookingRequest
            {
                Data = dto,
            };

            var res = await _bookingManager.UpdateBooking(request);

            if (res.Success) return Ok(res.Data);

            if (res.ErrorCode == Application.ErrorCode.NOT_FOUND)
            {
                return BadRequest(res);
            }
            else if (res.ErrorCode == Application.ErrorCode.INVALID_PERSON_ID)
            {
                return BadRequest(res);
            }
            else if (res.ErrorCode == Application.ErrorCode.MISSING_REQUIRED_INFORMATION)
            {
                return BadRequest(res);
            }
            else if (res.ErrorCode == Application.ErrorCode.INVALID_EMAIL)
            {
                return BadRequest(res);
            }
            else if (res.ErrorCode == Application.ErrorCode.COULD_NOT_STORE_DATA)
            {
                return BadRequest(res);
            }

            _logger.LogError("Response with unknown ErrorCode Returned");
            return BadRequest();
        }
    }
}
