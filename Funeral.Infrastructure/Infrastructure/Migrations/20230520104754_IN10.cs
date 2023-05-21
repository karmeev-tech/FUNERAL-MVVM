using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IN10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workers_StorageEntity_ShopNameId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "StorageEntity");

            migrationBuilder.DropIndex(
                name: "IX_Workers_ShopNameId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "ShopNameId",
                table: "Workers");

            migrationBuilder.AddColumn<string>(
                name: "ShopName",
                table: "Workers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopName",
                table: "Workers");

            migrationBuilder.AddColumn<int>(
                name: "ShopNameId",
                table: "Workers",
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
                name: "IX_Workers_ShopNameId",
                table: "Workers",
                column: "ShopNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_StorageEntity_ShopNameId",
                table: "Workers",
                column: "ShopNameId",
                principalTable: "StorageEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
