using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuessTheNumber.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AssignStatisticsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM GameResults");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "GameResults",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GameResults_UserId",
                table: "GameResults",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GameResults_Users_UserId",
                table: "GameResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameResults_Users_UserId",
                table: "GameResults");

            migrationBuilder.DropIndex(
                name: "IX_GameResults_UserId",
                table: "GameResults");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "GameResults");
        }
    }
}
