using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class AddPrivateEventBoolToBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrivateBooking",
                table: "Booking",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivateBooking",
                table: "Booking");
        }
    }
}
