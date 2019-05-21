using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomianEntity.Migrations
{
    public partial class addrelationitemmangment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LookUpId",
                table: "ShopItemMangment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemMangment_LookUpId",
                table: "ShopItemMangment",
                column: "LookUpId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_LookUpId",
                table: "ShopItemMangment",
                column: "LookUpId",
                principalTable: "ShopItemLookUp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_LookUpId",
                table: "ShopItemMangment");

            migrationBuilder.DropIndex(
                name: "IX_ShopItemMangment_LookUpId",
                table: "ShopItemMangment");

            migrationBuilder.DropColumn(
                name: "LookUpId",
                table: "ShopItemMangment");
        }
    }
}
