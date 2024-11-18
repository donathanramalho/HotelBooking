using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFktoBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuestId",
                table: "Bokings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Bokings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bokings_GuestId",
                table: "Bokings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Bokings_RoomId",
                table: "Bokings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bokings_Guests_GuestId",
                table: "Bokings",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bokings_Rooms_RoomId",
                table: "Bokings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bokings_Guests_GuestId",
                table: "Bokings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bokings_Rooms_RoomId",
                table: "Bokings");

            migrationBuilder.DropIndex(
                name: "IX_Bokings_GuestId",
                table: "Bokings");

            migrationBuilder.DropIndex(
                name: "IX_Bokings_RoomId",
                table: "Bokings");

            migrationBuilder.DropColumn(
                name: "GuestId",
                table: "Bokings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Bokings");
        }
    }
}
