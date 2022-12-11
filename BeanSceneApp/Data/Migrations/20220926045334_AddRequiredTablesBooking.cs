using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class AddRequiredTablesBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RequiredTables",
                table: "Booking",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequiredTables",
                table: "Booking");
        }
    }
}
