using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Storage
{
    /// <inheritdoc />
    public partial class InitialCreate8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StorageItems_StorageEntity_ShopNameId",
                table: "StorageItems");

            migrationBuilder.DropTable(
                name: "StorageEntity");

            migrationBuilder.DropIndex(
                name: "IX_StorageItems_ShopNameId",
                table: "StorageItems");

            migrationBuilder.DropColumn(
                name: "ShopNameId",
                table: "StorageItems");

            migrationBuilder.AddColumn<string>(
                name: "ShopName",
                table: "StorageItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopName",
                table: "StorageItems");

            migrationBuilder.AddColumn<int>(
                name: "ShopNameId",
                table: "StorageItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StorageEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StorageItems_ShopNameId",
                table: "StorageItems",
                column: "ShopNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_StorageItems_StorageEntity_ShopNameId",
                table: "StorageItems",
                column: "ShopNameId",
                principalTable: "StorageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
