using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class AddAvailabilityAndTimeslot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sitting");

            migrationBuilder.CreateTable(
                name: "Availability",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SittingType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    TablesAvailable = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Availability", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Timeslot",
                columns: table => new
                {
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslot", x => x.StartTime);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Availability");

            migrationBuilder.DropTable(
                name: "Timeslot");

            migrationBuilder.CreateTable(
                name: "Sitting",
                columns: table => new
                {
                    SittingType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "Time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitting", x => new { x.SittingType, x.Date });
                });

            migrationBuilder.InsertData(
                table: "Sitting",
                columns: new[] { "Date", "SittingType", "Capacity", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breakfast", 40, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0) });
        }
    }
}
