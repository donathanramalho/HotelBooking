using Application.Guests.Dtos;
using Application.Guests.Requests;
using Application.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("guest")]
    public class GuestController : ControllerBase
    {
        private readonly ILogger<GuestController> _logger;
        private readonly IGuestManager _guestManager;

        public GuestController(
            ILogger<GuestController> logger,
            IGuestManager guestManager)
        {
            _logger = logger;
            _guestManager = guestManager;
        }

        [NonAction]
        public IGuestManager Get_guestManager()
        {
            return _guestManager;
        }

        [HttpPost]
        public async Task<ActionResult<GuestDto>> Post(GuestDto guest, IGuestManager _guestManager)
        {
            var resquest = new CreateGuestRequest
            {
                Data = guest,
            };

            var res = await _guestManager.CreateGuest(resquest);

            if (res.Success) return Created("", res.Data);

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

            _logger.LogError("Response with unkwn ErrorCode Returned", res);
            return BadRequest();

        }

        [HttpGet]
        public async Task<ActionResult<GuestDto>> Get()
        {
            var res = await _guestManager.GetGuests();

            if (res.Success) return Ok(res.Data);

            return NotFound(res);
        }

        [HttpGet("{guestId}")]
        public async Task<ActionResult<GuestDto>> Get(int guestId)
        {
            var res = await _guestManager.GetGuest(guestId);

            if (res.Success) return Created("", res.Data);

            return NotFound(res);
        }

        [HttpPut("{guestId}")]
        public async Task<ActionResult<GuestDto>> Update(int guestId, GuestDto guest)
        {
            var request = new UpdateGuestRequest
            {
                GuestId = guestId,
                Data = guest
            };

            var res = await _guestManager.UpdateGuest(request);

            if (res.Success) return Ok(res.Data);

            _logger.LogError("Failed to update booking with ID {BookingId}", guestId);
            return BadRequest();
        }

        [HttpDelete("{guestId}")]
        public async Task<ActionResult<GuestDto>> Delete(int guestId)
        {
            var res = await _guestManager.DeleteGuest(guestId);

            if (res.Success) return NoContent();

            _logger.LogError("Failed to delete booking with ID {BookingId}", guestId);
            return NotFound(res);
        }
    }
}
