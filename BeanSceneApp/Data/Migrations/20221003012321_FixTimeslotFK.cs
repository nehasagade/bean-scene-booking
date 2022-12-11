using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class FixTimeslotFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Availability_StartTime",
                table: "Availability",
                column: "StartTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_Timeslot_StartTime",
                table: "Availability",
                column: "StartTime",
                principalTable: "Timeslot",
                principalColumn: "StartTime",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_Timeslot_StartTime",
                table: "Availability");

            migrationBuilder.DropIndex(
                name: "IX_Availability_StartTime",
                table: "Availability");
        }
    }
}
