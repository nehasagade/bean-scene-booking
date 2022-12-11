using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class AddAvailableTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableTable",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    AreaId = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TableNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableTable", x => new { x.Date, x.StartTime, x.AreaId, x.TableNum });
                    table.ForeignKey(
                        name: "FK_AvailableTable_Availability_Date_StartTime",
                        columns: x => new { x.Date, x.StartTime },
                        principalTable: "Availability",
                        principalColumns: new[] { "Date", "StartTime" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AvailableTable_Table_AreaId_TableNum",
                        columns: x => new { x.AreaId, x.TableNum },
                        principalTable: "Table",
                        principalColumns: new[] { "AreaId", "TableNum" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableTable_AreaId_TableNum",
                table: "AvailableTable",
                columns: new[] { "AreaId", "TableNum" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableTable");
        }
    }
}
