using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LanguageTrainer.Migrations
{
    /// <inheritdoc />
    public partial class CategoriesAndDifficultyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordDifficulties_Words_WordId",
                table: "WordDifficulties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordDifficulties",
                table: "WordDifficulties");

            migrationBuilder.RenameTable(
                name: "WordDifficulties",
                newName: "WordDifficulty");

            migrationBuilder.RenameIndex(
                name: "IX_WordDifficulties_WordId",
                table: "WordDifficulty",
                newName: "IX_WordDifficulty_WordId");

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Words",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordDifficulty",
                table: "WordDifficulty",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WordDifficulty_Words_WordId",
                table: "WordDifficulty",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WordDifficulty_Words_WordId",
                table: "WordDifficulty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WordDifficulty",
                table: "WordDifficulty");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Words");

            migrationBuilder.RenameTable(
                name: "WordDifficulty",
                newName: "WordDifficulties");

            migrationBuilder.RenameIndex(
                name: "IX_WordDifficulty_WordId",
                table: "WordDifficulties",
                newName: "IX_WordDifficulties_WordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WordDifficulties",
                table: "WordDifficulties",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WordDifficulties_Words_WordId",
                table: "WordDifficulties",
                column: "WordId",
                principalTable: "Words",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
