using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class fixBookingFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Booking_Date_StartTime",
                table: "Booking",
                columns: new[] { "Date", "StartTime" });

            migrationBuilder.AddForeignKey(
                name: "FK_Booking_Availability_Date_StartTime",
                table: "Booking",
                columns: new[] { "Date", "StartTime" },
                principalTable: "Availability",
                principalColumns: new[] { "Date", "StartTime" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Booking_Availability_Date_StartTime",
                table: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Booking_Date_StartTime",
                table: "Booking");
        }
    }
}
