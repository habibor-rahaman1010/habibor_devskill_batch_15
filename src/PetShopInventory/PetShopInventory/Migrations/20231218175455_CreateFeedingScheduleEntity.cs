using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopInventory.Migrations
{
    /// <inheritdoc />
    public partial class CreateFeedingScheduleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeedingSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeedingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialInstructions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedingSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedingSchedules_PetCages_CageId",
                        column: x => x.CageId,
                        principalTable: "PetCages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedingSchedules_CageId",
                table: "FeedingSchedules",
                column: "CageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedingSchedules");
        }
    }
}
