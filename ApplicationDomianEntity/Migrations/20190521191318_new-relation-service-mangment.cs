using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomianEntity.Migrations
{
    public partial class newrelationservicemangment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_LookUpId",
                table: "ShopItemMangment");

            migrationBuilder.RenameColumn(
                name: "LookUpId",
                table: "ShopItemMangment",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopItemMangment_LookUpId",
                table: "ShopItemMangment",
                newName: "IX_ShopItemMangment_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "ShopItemMangment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemMangment_BrandId",
                table: "ShopItemMangment",
                column: "BrandId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_BrandId",
                table: "ShopItemMangment",
                column: "BrandId",
                principalTable: "ShopItemLookUp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_CategoryId",
                table: "ShopItemMangment",
                column: "CategoryId",
                principalTable: "ShopItemLookUp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_BrandId",
                table: "ShopItemMangment");

            migrationBuilder.DropForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_CategoryId",
                table: "ShopItemMangment");

            migrationBuilder.DropIndex(
                name: "IX_ShopItemMangment_BrandId",
                table: "ShopItemMangment");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "ShopItemMangment");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ShopItemMangment",
                newName: "LookUpId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopItemMangment_CategoryId",
                table: "ShopItemMangment",
                newName: "IX_ShopItemMangment_LookUpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItemMangment_ShopItemLookUp_LookUpId",
                table: "ShopItemMangment",
                column: "LookUpId",
                principalTable: "ShopItemLookUp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
