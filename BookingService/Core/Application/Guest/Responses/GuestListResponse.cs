using Application.Dtos;

namespace Application.Guest.Responses
{
    public class GuestListResponse : Response
    {
        public List<GuestDto> Data;
    }
}