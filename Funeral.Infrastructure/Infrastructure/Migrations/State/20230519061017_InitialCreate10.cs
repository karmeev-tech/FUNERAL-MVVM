using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.State
{
    /// <inheritdoc />
    public partial class InitialCreate10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemComplectEntity_State_StateEntityId",
                table: "ItemComplectEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_State_StateEntityId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_State_OrderEntity_OrderId",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemComplectEntity",
                table: "ItemComplectEntity");

            migrationBuilder.RenameColumn(
                name: "StateEntityId",
                table: "Service",
                newName: "ComplexServiceEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_StateEntityId",
                table: "Service",
                newName: "IX_Service_ComplexServiceEntityId");

            migrationBuilder.RenameColumn(
                name: "StateEntityId",
                table: "ItemComplectEntity",
                newName: "ItemsEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemComplectEntity_StateEntityId",
                table: "ItemComplectEntity",
                newName: "IX_ItemComplectEntity_ItemsEntityId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "State",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComplectId",
                table: "State",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServicesId",
                table: "State",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemComplectEntity",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemComplectEntity",
                table: "ItemComplectEntity",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "ComplexServiceEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplexServiceEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_State_ComplectId",
                table: "State",
                column: "ComplectId");

            migrationBuilder.CreateIndex(
                name: "IX_State_ServicesId",
                table: "State",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemComplectEntity_ItemsEntity_ItemsEntityId",
                table: "ItemComplectEntity",
                column: "ItemsEntityId",
                principalTable: "ItemsEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ComplexServiceEntity_ComplexServiceEntityId",
                table: "Service",
                column: "ComplexServiceEntityId",
                principalTable: "ComplexServiceEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_State_ComplexServiceEntity_ServicesId",
                table: "State",
                column: "ServicesId",
                principalTable: "ComplexServiceEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_State_ItemsEntity_ComplectId",
                table: "State",
                column: "ComplectId",
                principalTable: "ItemsEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_State_OrderEntity_OrderId",
                table: "State",
                column: "OrderId",
                principalTable: "OrderEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemComplectEntity_ItemsEntity_ItemsEntityId",
                table: "ItemComplectEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ComplexServiceEntity_ComplexServiceEntityId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_State_ComplexServiceEntity_ServicesId",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_State_ItemsEntity_ComplectId",
                table: "State");

            migrationBuilder.DropForeignKey(
                name: "FK_State_OrderEntity_OrderId",
                table: "State");

            migrationBuilder.DropTable(
                name: "ComplexServiceEntity");

            migrationBuilder.DropTable(
                name: "ItemsEntity");

            migrationBuilder.DropIndex(
                name: "IX_State_ComplectId",
                table: "State");

            migrationBuilder.DropIndex(
                name: "IX_State_ServicesId",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemComplectEntity",
                table: "ItemComplectEntity");

            migrationBuilder.DropColumn(
                name: "ComplectId",
                table: "State");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "State");

            migrationBuilder.RenameColumn(
                name: "ComplexServiceEntityId",
                table: "Service",
                newName: "StateEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ComplexServiceEntityId",
                table: "Service",
                newName: "IX_Service_StateEntityId");

            migrationBuilder.RenameColumn(
                name: "ItemsEntityId",
                table: "ItemComplectEntity",
                newName: "StateEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemComplectEntity_ItemsEntityId",
                table: "ItemComplectEntity",
                newName: "IX_ItemComplectEntity_StateEntityId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "State",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ItemComplectEntity",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemComplectEntity",
                table: "ItemComplectEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemComplectEntity_State_StateEntityId",
                table: "ItemComplectEntity",
                column: "StateEntityId",
                principalTable: "State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_State_StateEntityId",
                table: "Service",
                column: "StateEntityId",
                principalTable: "State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_State_OrderEntity_OrderId",
                table: "State",
                column: "OrderId",
                principalTable: "OrderEntity",
                principalColumn: "Id");
        }
    }
}
