using Application.Dtos;
using Application.Guest.Requests;
using Application.Ports;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost]
        public async Task<ActionResult<GuestDto>> Post(GuestDto guest)
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

            _logger.LogError("Response with unknown ErrorCode Returned");
            return BadRequest();

        }

        [HttpGet]
        public async Task<ActionResult<GuestDto>> Get(int guestId)
        {
            var res = await _guestManager.GetGuest(guestId);

            if (res.Success) return Created("", res.Data);

            return NotFound(res);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var res = await _guestManager.GetAll();

            if (res.Success) return Ok(res.Data);

            return BadRequest(res);
        }

        [HttpDelete]
        public async Task<ActionResult<GuestDto>> Delete(int guestId)
        {
            var res = await _guestManager.RemoveGuest(guestId);

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
        public async Task<ActionResult<GuestDto>> Update(GuestDto dto)
        {
            var request = new UpdateGuestRequest
            {
                Data = dto,
            };

            var res = await _guestManager.UpdateGuest(request);

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
