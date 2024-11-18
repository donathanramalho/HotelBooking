
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Guests.Entities;



namespace Data.Guests
{
    public class GuestConfiguration : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(e => e.Id);
            builder.OwnsOne(e => e.DocumentId)
                .Property(e => e.IdNumber);

            builder.OwnsOne(e => e.DocumentId)
                .Property(e => e.DocumentType);//lambda

        }

    }
}
