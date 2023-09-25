using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Bus",
                table: "Trip",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "BusCompany",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusName",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Seats",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusCompany",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "BusName",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Trip");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Trip",
                newName: "Bus");
        }
    }
}
