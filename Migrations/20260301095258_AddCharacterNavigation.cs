using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnDCharacterManager.Migrations
{
    /// <inheritdoc />
    public partial class AddCharacterNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Abilities",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                table: "Abilities",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Items",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CharacterId",
                table: "Abilities",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Characters_CharacterId",
                table: "Abilities",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Characters_CharacterId",
                table: "Items",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
