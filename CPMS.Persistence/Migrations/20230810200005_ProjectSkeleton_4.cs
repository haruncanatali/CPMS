using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPMS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ProjectSkeleton_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CompanyId",
                table: "ParkingServices",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingServices_CompanyId",
                table: "ParkingServices",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingServices_Companies_CompanyId",
                table: "ParkingServices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingServices_Companies_CompanyId",
                table: "ParkingServices");

            migrationBuilder.DropIndex(
                name: "IX_ParkingServices_CompanyId",
                table: "ParkingServices");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "ParkingServices");
        }
    }
}
