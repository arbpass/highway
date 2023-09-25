using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedSeatsDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    LC1 = table.Column<bool>(type: "bit", nullable: false),
                    LC2 = table.Column<bool>(type: "bit", nullable: false),
                    LC3 = table.Column<bool>(type: "bit", nullable: false),
                    LC4 = table.Column<bool>(type: "bit", nullable: false),
                    LC5 = table.Column<bool>(type: "bit", nullable: false),
                    LC6 = table.Column<bool>(type: "bit", nullable: false),
                    LC7 = table.Column<bool>(type: "bit", nullable: false),
                    LC8 = table.Column<bool>(type: "bit", nullable: false),
                    LC9 = table.Column<bool>(type: "bit", nullable: false),
                    LC10 = table.Column<bool>(type: "bit", nullable: false),
                    LC11 = table.Column<bool>(type: "bit", nullable: false),
                    LC12 = table.Column<bool>(type: "bit", nullable: false),
                    LC13 = table.Column<bool>(type: "bit", nullable: false),
                    LC14 = table.Column<bool>(type: "bit", nullable: false),
                    LC15 = table.Column<bool>(type: "bit", nullable: false),
                    LC16 = table.Column<bool>(type: "bit", nullable: false),
                    LC17 = table.Column<bool>(type: "bit", nullable: false),
                    LC18 = table.Column<bool>(type: "bit", nullable: false),
                    LC19 = table.Column<bool>(type: "bit", nullable: false),
                    LC20 = table.Column<bool>(type: "bit", nullable: false),
                    LC21 = table.Column<bool>(type: "bit", nullable: false),
                    LC22 = table.Column<bool>(type: "bit", nullable: false),
                    LC23 = table.Column<bool>(type: "bit", nullable: false),
                    LC24 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seats");
        }
    }
}
