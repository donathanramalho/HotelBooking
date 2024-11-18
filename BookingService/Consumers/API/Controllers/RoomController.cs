using Application.Ports;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos;
using Application.Rooms.Requests;

namespace API.Controllers
{
    [ApiController]
    [Route("room")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IRoomManager _roomManager;

        public RoomController(
            ILogger<RoomController> logger,
            IRoomManager roomManager)
        {
            _logger = logger;
            _roomManager = roomManager;
        }

        [NonAction]
        public IRoomManager Get_roomManager()
        {
            return _roomManager;
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> Post(RoomDto roomDto)
        {
            try
            {
                if (string.IsNullOrEmpty(roomDto.Name) || roomDto.Price <= 0)
                {
                    _logger.LogWarning("Invalid RoomDto provided: {@RoomDto}", roomDto);
                    return BadRequest(new { message = "Invalid room data." });
                }

                // Mapear o DTO para a entidade
                _logger.LogInformation("Mapping RoomDto to Room entity: {@RoomDto}", roomDto);
                var room = RoomDto.MapToEntity(roomDto);

                // Simulação: Adicione lógica de salvamento aqui
                _logger.LogInformation("Room successfully mapped and ready for database: {@Room}", room);

                return Created("", roomDto);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError("Validation error: {Message}", ex.Message);
                return BadRequest(new { message = "Validation error", details = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError("Unexpected error occurred: {Message}\nStackTrace: {StackTrace}", ex.Message, ex.StackTrace);
                return StatusCode(500, new { message = "Internal Server Error", details = ex.Message });
            }

            //var resquest = new CreateRoomRequest
            //{
            //    Data = room,
            //};

            //var res = await _roomManager.CreateRoom(resquest);

            //if (res.Success) return Created("", res.Data);

            //_logger.LogError("Response with unkwn ErrorCode Returned", res);
            //return BadRequest();

        }

        [HttpGet]
        public async Task<ActionResult<RoomDto>> Get()
        {
            var res = await _roomManager.GetRooms();

            if (res.Success) return Ok(res.Data);

            return NotFound(res);
        }

        [HttpGet("{roomId}")]
        public async Task<ActionResult<RoomDto>> GetById(int roomId)
        {
            var res = await _roomManager.GetRoom(roomId);

            if (res.Success) return Created("", res.Data);

            return NotFound(res);
        }

        [HttpPut("{roomId}")]
        public async Task<ActionResult<RoomDto>> Update(int roomId, RoomDto room)
        {
            var request = new UpdateRoomRequest
            {
                RoomId = roomId,
                Data = room
            };

            var res = await _roomManager.UpdateRoom(request);

            if (res.Success) return Ok(res.Data);

            _logger.LogError("Failed to update booking with ID {BookingId}", roomId);
            return BadRequest();
        }

        [HttpDelete("{roomId}")]
        public async Task<ActionResult<RoomDto>> Delete(int roomId)
        {
            var res = await _roomManager.DeleteRoom(roomId);

            if (res.Success) return NoContent();

            _logger.LogError("Failed to delete booking with ID {BookingId}", roomId);
            return NotFound(res);
        }
    }

}