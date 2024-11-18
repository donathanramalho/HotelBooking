using Domain.Guests.Enums;

namespace Domain.Guests.ValueObjects;
public class PersonId
{
    public string IdNumber { get; set; }
    public DocumentType DocumentType { get; set; }
}
