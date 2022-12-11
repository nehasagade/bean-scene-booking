using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class addAvailableTablesToBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "AvailableTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTable_BookingId",
                table: "AvailableTable",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableTable_Booking_BookingId",
                table: "AvailableTable",
                column: "BookingId",
                principalTable: "Booking",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableTable_Booking_BookingId",
                table: "AvailableTable");

            migrationBuilder.DropIndex(
                name: "IX_AvailableTable_BookingId",
                table: "AvailableTable");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "AvailableTable");
        }
    }
}
