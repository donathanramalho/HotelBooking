using Domain.Rooms.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Rooms
{
    public class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.OwnsOne(r => r.Price, price =>
            {
                price.Property(p => p.Value)
                    .HasPrecision(18, 2) // Define precisão e escala para o campo 'Value'
                    .HasColumnName("PriceValue"); // Opcional: Define o nome da coluna no banco de dados

                price.Property(p => p.Currency)
                    .HasColumnName("Currency"); // Opcional: Define o nome da coluna no banco de dados
            });
        }
    }
}
