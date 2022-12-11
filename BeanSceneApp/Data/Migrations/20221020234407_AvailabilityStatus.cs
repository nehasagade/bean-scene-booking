using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class AvailabilityStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Availability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "SittingType",
                column: "SittingName",
                value: "Private Event");

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 1 },
                column: "Note",
                value: null);

            migrationBuilder.InsertData(
                table: "Table",
                columns: new[] { "AreaId", "TableNum", "Note", "TableCapacity" },
                values: new object[,]
                {
                    { "B", 1, null, 4 },
                    { "B", 2, null, 4 },
                    { "B", 3, null, 4 },
                    { "B", 4, null, 4 },
                    { "B", 5, null, 4 },
                    { "B", 6, null, 4 },
                    { "B", 7, null, 4 },
                    { "B", 8, null, 4 },
                    { "B", 9, null, 4 },
                    { "B", 10, null, 4 },
                    { "M", 2, null, 4 },
                    { "M", 3, null, 4 },
                    { "M", 4, null, 4 },
                    { "M", 5, null, 4 },
                    { "M", 6, null, 4 },
                    { "M", 7, null, 4 },
                    { "M", 8, null, 4 },
                    { "M", 9, null, 4 },
                    { "M", 10, null, 4 },
                    { "O", 1, null, 4 },
                    { "O", 2, null, 4 },
                    { "O", 3, null, 4 },
                    { "O", 4, null, 4 },
                    { "O", 5, null, 4 },
                    { "O", 6, null, 4 },
                    { "O", 7, null, 4 },
                    { "O", 8, null, 4 },
                    { "O", 9, null, 4 },
                    { "O", 10, null, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SittingType",
                keyColumn: "SittingName",
                keyValue: "Private Event");

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 1 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 2 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 3 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 4 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 5 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 6 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 7 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 8 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 9 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 10 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 2 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 3 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 4 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 5 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 6 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 7 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 8 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 9 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 10 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 1 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 2 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 3 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 4 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 5 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 6 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 7 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 8 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 9 });

            migrationBuilder.DeleteData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 10 });

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Availability");

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 1 },
                column: "Note",
                value: "Window seat");
        }
    }
}
