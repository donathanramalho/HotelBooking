using Domain.Enums;
using Domain.ValueObjects;

namespace Application.Dtos
{
    public class GuestDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public int IdTypeCode { get; set; }

        public static Domain.Entities.Guest MapToEntity(GuestDto guestDto)
        {
            return new Domain.Entities.Guest
            {
                Name = guestDto.Name,
                Surname = guestDto.Surname,
                Email = guestDto.Email,
                DocumentId = new PersonId
                {
                    IdNumber = guestDto.IdNumber.ToString(),
                    DocumentType = (DocumentType)guestDto.IdTypeCode
                }
            };

        }

        public static GuestDto MapToDto(Domain.Entities.Guest guest)
        {
            return new GuestDto
            {
                Name = guest.Name,
                Surname = guest.Surname,
                Email = guest.Email,
                IdNumber = guest.DocumentId.IdNumber,
                IdTypeCode = (int)guest.DocumentId.DocumentType
            };
        }

    }
}
