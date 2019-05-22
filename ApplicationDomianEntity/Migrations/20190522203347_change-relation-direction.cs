using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomianEntity.Migrations
{
    public partial class changerelationdirection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_ShopItemLookUpId",
                table: "ShopItemMangment");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_ShopItemLookUpId1",
                table: "ShopItemMangment");

            migrationBuilder.DropIndex(
                name: "IX_ShopItemMangment_ShopItemLookUpId",
                table: "ShopItemMangment");

            migrationBuilder.DropIndex(
                name: "IX_ShopItemMangment_ShopItemLookUpId1",
                table: "ShopItemMangment");

            migrationBuilder.DropColumn(
                name: "ShopItemLookUpId",
                table: "ShopItemMangment");

            migrationBuilder.DropColumn(
                name: "ShopItemLookUpId1",
                table: "ShopItemMangment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopItemLookUpId",
                table: "ShopItemMangment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShopItemLookUpId1",
                table: "ShopItemMangment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemMangment_ShopItemLookUpId",
                table: "ShopItemMangment",
                column: "ShopItemLookUpId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemMangment_ShopItemLookUpId1",
                table: "ShopItemMangment",
                column: "ShopItemLookUpId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_ShopItemLookUpId",
                table: "ShopItemMangment",
                column: "ShopItemLookUpId",
                principalTable: "ShopItemLookUp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_ShopItemLookUpId1",
                table: "ShopItemMangment",
                column: "ShopItemLookUpId1",
                principalTable: "ShopItemLookUp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
