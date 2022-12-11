using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class AddSittingAndSittingType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sitting",
                columns: table => new
                {
                    SittingType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sitting", x => new { x.SittingType, x.Date });
                });

            migrationBuilder.CreateTable(
                name: "SittingType",
                columns: table => new
                {
                    SittingName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SittingType", x => x.SittingName);
                });

            migrationBuilder.InsertData(
                table: "Sitting",
                columns: new[] { "Date", "SittingType", "Capacity", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Breakfast", 40, new TimeSpan(0, 11, 0, 0, 0), new TimeSpan(0, 7, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "SittingType",
                column: "SittingName",
                values: new object[]
                {
                    "Breakfast",
                    "Dinner",
                    "Lunch"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sitting");

            migrationBuilder.DropTable(
                name: "SittingType");
        }
    }
}
