using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomianEntity.Migrations
{
    public partial class testing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItem_ShopItemMangment_ElectricCigaretMangmentId",
                table: "ShopItem");

            migrationBuilder.DropIndex(
                name: "IX_ShopItem_ElectricCigaretMangmentId",
                table: "ShopItem");

            migrationBuilder.AlterColumn<int>(
                name: "TotalyInserted",
                table: "ShopItemMangment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TotalyAvilable",
                table: "ShopItemMangment",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ElectricCigaretId",
                table: "ShopItemMangment",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ShopItem",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.CreateIndex(
                name: "IX_ShopItem_ElectricCigaretMangmentId",
                table: "ShopItem",
                column: "ElectricCigaretMangmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItem_ShopItemMangment_ElectricCigaretMangmentId",
                table: "ShopItem",
                column: "ElectricCigaretMangmentId",
                principalTable: "ShopItemMangment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopItem_ShopItemMangment_ElectricCigaretMangmentId",
                table: "ShopItem");

            migrationBuilder.DropIndex(
                name: "IX_ShopItem_ElectricCigaretMangmentId",
                table: "ShopItem");

            migrationBuilder.DropColumn(
                name: "ElectricCigaretId",
                table: "ShopItemMangment");

            migrationBuilder.AlterColumn<int>(
                name: "TotalyInserted",
                table: "ShopItemMangment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalyAvilable",
                table: "ShopItemMangment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "ShopItem",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopItem_ElectricCigaretMangmentId",
                table: "ShopItem",
                column: "ElectricCigaretMangmentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopItem_ShopItemMangment_ElectricCigaretMangmentId",
                table: "ShopItem",
                column: "ElectricCigaretMangmentId",
                principalTable: "ShopItemMangment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
