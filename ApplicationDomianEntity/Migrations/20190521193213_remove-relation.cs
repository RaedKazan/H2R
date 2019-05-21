using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomianEntity.Migrations
{
    public partial class removerelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_ShopItemMangment_CategoryId",
                table: "ShopItemMangment");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "ShopItemMangment");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ShopItemMangment");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "ShopItemMangment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ShopItemMangment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemMangment_BrandId",
                table: "ShopItemMangment",
                column: "BrandId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopItemMangment_CategoryId",
                table: "ShopItemMangment",
                column: "CategoryId",
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
    }
}
