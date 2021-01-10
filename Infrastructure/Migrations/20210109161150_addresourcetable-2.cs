using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class addresourcetable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Products_ProductId",
                table: "Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                table: "Resource");

            migrationBuilder.RenameTable(
                name: "Resource",
                newName: "Resources");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_ProductId",
                table: "Resources",
                newName: "IX_Resources_ProductId");

            migrationBuilder.AlterColumn<float>(
                name: "Discount",
                table: "Products",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Products_ProductId",
                table: "Resources",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Products_ProductId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "Resource");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_ProductId",
                table: "Resource",
                newName: "IX_Resource_ProductId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                table: "Resource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Products_ProductId",
                table: "Resource",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
