using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class MaxTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxTables",
                table: "Availability",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.AlterColumn<string>(
            //    name: "TableName",
            //    table: "Table",
            //    type: "nvarchar(2)",
            //    maxLength: 2,
            //    nullable: true,
            //    computedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(2)",
            //    oldMaxLength: 2,
            //    oldComputedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])");

            migrationBuilder.InsertData(
                table: "Timeslot",
                column: "StartTime",
                values: new object[]
                {
                    new TimeSpan(0, 8, 0, 0, 0),
                    new TimeSpan(0, 9, 0, 0, 0),
                    new TimeSpan(0, 10, 0, 0, 0),
                    new TimeSpan(0, 11, 0, 0, 0),
                    new TimeSpan(0, 12, 0, 0, 0),
                    new TimeSpan(0, 13, 0, 0, 0),
                    new TimeSpan(0, 14, 0, 0, 0),
                    new TimeSpan(0, 15, 0, 0, 0),
                    new TimeSpan(0, 16, 0, 0, 0),
                    new TimeSpan(0, 17, 0, 0, 0),
                    new TimeSpan(0, 18, 0, 0, 0),
                    new TimeSpan(0, 19, 0, 0, 0),
                    new TimeSpan(0, 20, 0, 0, 0),
                    new TimeSpan(0, 21, 0, 0, 0)
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 8, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 9, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 10, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 11, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 12, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 13, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 14, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 15, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 16, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 17, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 18, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 19, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 20, 0, 0, 0));

            migrationBuilder.DeleteData(
                table: "Timeslot",
                keyColumn: "StartTime",
                keyValue: new TimeSpan(0, 21, 0, 0, 0));

            migrationBuilder.DropColumn(
                name: "MaxTables",
                table: "Availability");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TableName",
            //    table: "Table",
            //    type: "nvarchar(2)",
            //    maxLength: 2,
            //    nullable: false,
            //    computedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])",
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(2)",
            //    oldMaxLength: 2,
            //    oldNullable: true,
            //    oldComputedColumnSql: "[AreaId] + CONVERT(NVARCHAR, [TableNum])");
        }
    }
}
