using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Storage
{
    /// <inheritdoc />
    public partial class InitialCreate7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageItems_Storages_ShopNameId",
                table: "StorageItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Storages",
                table: "Storages");

            migrationBuilder.RenameTable(
                name: "Storages",
                newName: "StorageEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StorageEntity",
                table: "StorageEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageItems_StorageEntity_ShopNameId",
                table: "StorageItems",
                column: "ShopNameId",
                principalTable: "StorageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageItems_StorageEntity_ShopNameId",
                table: "StorageItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StorageEntity",
                table: "StorageEntity");

            migrationBuilder.RenameTable(
                name: "StorageEntity",
                newName: "Storages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Storages",
                table: "Storages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageItems_Storages_ShopNameId",
                table: "StorageItems",
                column: "ShopNameId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
