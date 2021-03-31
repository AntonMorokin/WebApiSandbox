using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Database.Migrations
{
    public partial class CarModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Cars",
                newName: "State");

            migrationBuilder.AddColumn<string>(
                name: "ParkingAddress",
                table: "Cars",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkingAddress",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Cars",
                newName: "Status");
        }
    }
}
