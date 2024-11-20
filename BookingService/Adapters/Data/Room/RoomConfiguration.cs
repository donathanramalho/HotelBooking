using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Room
{
    public class RoomConfiguration : IEntityTypeConfiguration<Domain.Entities.Room>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Room> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.OwnsOne(e => e.Price)
                .Property(e => e.Currency);

            builder.OwnsOne(e => e.Price)
                .Property(e => e.Value);
        }


    }
}
