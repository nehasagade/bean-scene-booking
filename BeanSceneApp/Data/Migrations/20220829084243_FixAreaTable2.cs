using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class FixAreaTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "Table",
                type: "nvarchar(2)",
                maxLength: 2,
                nullable: false,
                computedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComputedColumnSql: "[AreaId] + [TableNum]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TableName",
                table: "Table",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "[AreaId] + [TableNum]",
                oldClrType: typeof(string),
                oldType: "nvarchar(2)",
                oldMaxLength: 2,
                oldComputedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])");
        }
    }
}
