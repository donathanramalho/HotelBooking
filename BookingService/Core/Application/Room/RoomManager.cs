using Application.Dtos;
using Application.Ports;
using Application.Responses;
using Application.Room.Requests;
using Application.Room.Responses;
using Domain.Exceptions;
using Domain.Ports;
using Domain.Room.Exceptions;

namespace Application.Room
{
    public class RoomManager : IRoomManager
    {
        private readonly IRoomRepository _roomRepository;

        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<RoomResponse> CreateRoom(CreateRoomRequest request)
        {
            try
            {
                var room = RoomDto.MapToEntity(request.Data);

                var result = await this._roomRepository.SaveRoom(room);

                // request.Data.Id = result.Id;

                return new RoomResponse()
                {
                    Data = request.Data,
                    Success = true,
                };
            }
            catch (MissingRequiredInformationException)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.MISSING_REQUIRED_INFORMATION,
                    Message = "Missing information"
                };
            }
            catch (InvalidPriceException)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.INVALID_PRICE,
                    Message = "The price is invalid"
                };
            }
            catch (Exception)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.COULD_NOT_STORE_DATA,
                    Message = "There was an error when saving to DB"
                };
            }
        }

        public async Task<RoomResponse> GetRoom(int id)
        {
            var room = await _roomRepository.GetRoom(id);

            if (room == null)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.NOT_FOUND,
                    Message = "Room not found"
                };
            }

            return new RoomResponse()
            {
                Data = RoomDto.MapToDto(room),
                Success = true,
            };
        }

        public async Task<RoomListResponse> GetAllRooms()
        {
            try
            {
                var rooms = await this._roomRepository.GetAllRooms();

                var list = new List<RoomDto>();

                foreach (var room in rooms)
                {
                    list.Add(RoomDto.MapToDto(room));
                }

                return new RoomListResponse()
                {
                    Success = true,
                    Data = list,
                };
            }
            catch (Exception)
            {
                return new RoomListResponse()
                {
                    Success = false,
                    ErrorCode = ErrorCode.COULD_NOT_RETRIEVE_DATA,
                    Message = "There was an error when saving to DB"
                };
            }
        }

        public async Task<RoomResponse> UpdateRoom(CreateRoomRequest request)
        {
            try
            {
                var room = RoomDto.MapToEntity(request.Data);

                await this._roomRepository.UpdateRoom(room);

                return new RoomResponse()
                {
                    Data = request.Data,
                    Success = true,
                };
            }
            catch (MissingRequiredInformationException)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.MISSING_REQUIRED_INFORMATION,
                    Message = "Missing information"
                };
            }
            catch (InvalidPriceException)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.INVALID_PRICE,
                    Message = "The price is invalid"
                };
            }
            catch (Exception)
            {
                return new RoomResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.COULD_NOT_STORE_DATA,
                    Message = "There was an error when saving to DB"
                };
            }
        }

        public async Task<RoomResponse> RemoveRoom(int id)
        {
            try
            {
                var deleted = await _roomRepository.DeleteRoom(id);

                return new RoomResponse()
                {
                    Success = true,
                    Data = RoomDto.MapToDto(deleted),
                };
            }
            catch (NotFoundException)
            {
                return new RoomResponse()
                {
                    Success = false,
                    ErrorCode = ErrorCode.GUEST_NOT_FOUND
                };
            }
            catch (Exception)
            {
                return new RoomResponse()
                {
                    Success = false,
                    ErrorCode = ErrorCode.COULD_NOT_DELETE_DATA
                };
            }
        }
    }
}