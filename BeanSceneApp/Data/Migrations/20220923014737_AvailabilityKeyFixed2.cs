using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class AvailabilityKeyFixed2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Availability",
                table: "Availability");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Availability",
                table: "Availability",
                columns: new[] { "Date", "StartTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Availability",
                table: "Availability");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Availability",
                table: "Availability",
                columns: new[] { "SittingType", "Date", "StartTime" });
        }
    }
}
