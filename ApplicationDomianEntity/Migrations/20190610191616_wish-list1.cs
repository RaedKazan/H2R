using Microsoft.EntityFrameworkCore.Migrations;

namespace ApplicationDomianEntity.Migrations
{
    public partial class wishlist1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_UserId1",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_UserId1",
                table: "WishList");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "WishList");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "WishList",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId",
                table: "WishList",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_UserId",
                table: "WishList",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishList_AspNetUsers_UserId",
                table: "WishList");

            migrationBuilder.DropIndex(
                name: "IX_WishList_UserId",
                table: "WishList");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "WishList",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "WishList",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishList_UserId1",
                table: "WishList",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WishList_AspNetUsers_UserId1",
                table: "WishList",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
