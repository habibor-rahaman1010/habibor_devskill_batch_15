using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopInventory.Migrations
{
    /// <inheritdoc />
    public partial class EditPetShopEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetPurchases_PetPurchaseId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "PetPurchaseId",
                table: "Pets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetPurchases_PetPurchaseId",
                table: "Pets",
                column: "PetPurchaseId",
                principalTable: "PetPurchases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetPurchases_PetPurchaseId",
                table: "Pets");

            migrationBuilder.AlterColumn<int>(
                name: "PetPurchaseId",
                table: "Pets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetPurchases_PetPurchaseId",
                table: "Pets",
                column: "PetPurchaseId",
                principalTable: "PetPurchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
