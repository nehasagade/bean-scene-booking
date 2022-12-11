using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeanSceneApp.Data.Migrations
{
    public partial class FixSittingTypeFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Availability_SittingType",
                table: "Availability",
                column: "SittingType");

            migrationBuilder.AddForeignKey(
                name: "FK_Availability_SittingType_SittingType",
                table: "Availability",
                column: "SittingType",
                principalTable: "SittingType",
                principalColumn: "SittingName",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Availability_SittingType_SittingType",
                table: "Availability");

            migrationBuilder.DropIndex(
                name: "IX_Availability_SittingType",
                table: "Availability");
        }
    }
}
