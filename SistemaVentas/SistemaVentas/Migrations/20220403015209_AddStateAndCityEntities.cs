using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaVentas.Migrations
{
    public partial class AddStateAndCityEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.ID);
                    table.ForeignKey(
                        name: "FK_states_countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_cities_states_StateID",
                        column: x => x.StateID,
                        principalTable: "states",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cities_Name_StateID",
                table: "cities",
                columns: new[] { "Name", "StateID" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_StateID",
                table: "cities",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_states_CountryID",
                table: "states",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_states_Name_CountryID",
                table: "states",
                columns: new[] { "Name", "CountryID" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "states");
        }
    }
}
