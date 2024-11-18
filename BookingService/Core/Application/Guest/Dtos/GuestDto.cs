using Domain.Guests.Entities;
using Domain.Guests.Enums;
using Domain.Guests.ValueObjects;

namespace Application.Guests.Dtos
{
    public class GuestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string IdNumber { get; set; }
        public int IdTypeCode { get; set; }

        public static Guest MapToEntity(GuestDto guestDto)
        {
            return new Guest
            {
                Id = guestDto.Id,
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

        public static GuestDto MapToDto(Guest guest)
        {
            return new GuestDto
            {
                Id = guest.Id,
                Name = guest.Name,
                Surname = guest.Surname,
                Email = guest.Email,
                IdNumber = guest.DocumentId.IdNumber,
                IdTypeCode = (int)guest.DocumentId.DocumentType
            };
        }

    }
}
