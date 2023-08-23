using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuessTheNumber.Migrations
{
    /// <inheritdoc />
    public partial class NeuNeuUpdatedGameResultModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameWon = table.Column<bool>(type: "bit", nullable: false),
                    TotalAttempts = table.Column<int>(type: "int", nullable: false),
                    AttemptsTaken = table.Column<int>(type: "int", nullable: false),
                    RiddledNumber = table.Column<int>(type: "int", nullable: false),
                    HintsEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameResults");
        }
    }
}
