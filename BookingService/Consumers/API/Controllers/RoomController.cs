using Application.Dtos;
using Application.Ports;
using Application.Room.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<BookingController> _logger;
        private readonly IRoomManager _roomManager;

        public RoomController(
            ILogger<BookingController> logger,
            IRoomManager roomManager)
        {
            _logger = logger;
            _roomManager = roomManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RoomDto room)
        {
            var resquest = new CreateRoomRequest
            {
                Data = room,
            };

            var res = await _roomManager.CreateRoom(resquest);

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
            var res = await _roomManager.GetRoom(guestId);

            if (res.Success) return Created("", res.Data);

            return NotFound(res);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var res = await _roomManager.GetAllRooms();

            if (res.Success) return Ok(res.Data);

            if (res.ErrorCode == Application.ErrorCode.NOT_FOUND)
            {
                return NotFound(res);
            }
            else if (res.ErrorCode == Application.ErrorCode.COULD_NOT_RETRIEVE_DATA)
            {
                return BadRequest(res);
            }

            _logger.LogError("Response with unknown ErrorCode Returned");
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoomDto room)
        {
            var request = new CreateRoomRequest()
            {
                Data = room,
            };

            var res = await _roomManager.UpdateRoom(request);

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

        [HttpDelete]
        public async Task<IActionResult> Delete(int roomId)
        {
            var res = await _roomManager.RemoveRoom(roomId);

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
    }
}