using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class FixAreaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaId = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    AreaId = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    TableNum = table.Column<int>(type: "int", nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: false, computedColumnSql: "[AreaId] + [TableNum]"),
                    TableCapacity = table.Column<int>(type: "int", nullable: false, defaultValue: 4),
                    Note = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => new { x.AreaId, x.TableNum });
                    table.ForeignKey(
                        name: "FK_Table_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "AreaId", "Name" },
                values: new object[] { "B", "Balcony" });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "AreaId", "Name" },
                values: new object[] { "M", "Main" });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "AreaId", "Name" },
                values: new object[] { "O", "Outside" });

            migrationBuilder.InsertData(
                table: "Table",
                columns: new[] { "AreaId", "TableNum", "Note", "TableCapacity" },
                values: new object[] { "M", 1, "Window seat", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
