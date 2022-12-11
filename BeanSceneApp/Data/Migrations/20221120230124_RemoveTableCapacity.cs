using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class RemoveTableCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableCapacity",
                table: "Table");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TableName",
            //    table: "Table",
            //    type: "nvarchar(4)",
            //    maxLength: 4,
            //    nullable: true,
            //    computedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(2)",
            //    oldMaxLength: 2,
            //    oldNullable: true,
            //    oldComputedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TableCapacity",
                table: "Table",
                type: "int",
                nullable: false,
                defaultValue: 4);

            //migrationBuilder.AlterColumn<string>(
            //    name: "TableName",
            //    table: "Table",
            //    type: "nvarchar(2)",
            //    maxLength: 2,
            //    nullable: true,
            //    computedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(4)",
            //    oldMaxLength: 4,
            //    oldNullable: true,
            //    oldComputedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])");

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 1 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 2 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 3 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 4 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 5 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 6 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 7 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 8 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 9 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "B", 10 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 1 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 2 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 3 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 4 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 5 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 6 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 7 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 8 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 9 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "M", 10 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 1 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 2 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 3 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 4 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 5 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 6 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 7 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 8 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 9 },
                column: "TableCapacity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Table",
                keyColumns: new[] { "AreaId", "TableNum" },
                keyValues: new object[] { "O", 10 },
                column: "TableCapacity",
                value: 4);
        }
    }
}
