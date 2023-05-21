using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.State
{
    /// <inheritdoc />
    public partial class migs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientOrderEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    ThirdName = table.Column<string>(type: "TEXT", nullable: false),
                    Adress = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Cemetry = table.Column<string>(type: "TEXT", nullable: false),
                    Telegram = table.Column<string>(type: "TEXT", nullable: false),
                    Passport = table.Column<string>(type: "TEXT", nullable: false),
                    DeliveryPlace = table.Column<string>(type: "TEXT", nullable: false),
                    DateToday = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreation = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientOrderEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlowershedEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Section = table.Column<string>(type: "TEXT", nullable: false),
                    NoInstal = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowershedEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuneralBaseEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryFuneral = table.Column<string>(type: "TEXT", nullable: false),
                    ModelFuneral = table.Column<string>(type: "TEXT", nullable: false),
                    Rock = table.Column<string>(type: "TEXT", nullable: false),
                    Looks = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuneralBaseEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuneralEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    UpPart = table.Column<string>(type: "TEXT", nullable: false),
                    DownPart = table.Column<string>(type: "TEXT", nullable: false),
                    Other = table.Column<string>(type: "TEXT", nullable: false),
                    Epitafia = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuneralEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstalEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Idicate = table.Column<string>(type: "TEXT", nullable: false),
                    InstalPrice = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstalEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StandEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Section = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StelaEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Size = table.Column<string>(type: "TEXT", nullable: false),
                    Section = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StelaEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BaseId = table.Column<int>(type: "INTEGER", nullable: false),
                    StelaId = table.Column<int>(type: "INTEGER", nullable: false),
                    StandId = table.Column<int>(type: "INTEGER", nullable: false),
                    FlowershedId = table.Column<int>(type: "INTEGER", nullable: false),
                    Polishing = table.Column<string>(type: "TEXT", nullable: false),
                    DeadassCount = table.Column<int>(type: "INTEGER", nullable: false),
                    InstalId = table.Column<int>(type: "INTEGER", nullable: false),
                    FuneralId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<string>(type: "TEXT", nullable: false),
                    Prepayment = table.Column<string>(type: "TEXT", nullable: false),
                    Remainder = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderEntity_ClientOrderEntity_ClientOrderId",
                        column: x => x.ClientOrderId,
                        principalTable: "ClientOrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntity_FlowershedEntity_FlowershedId",
                        column: x => x.FlowershedId,
                        principalTable: "FlowershedEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntity_FuneralBaseEntity_BaseId",
                        column: x => x.BaseId,
                        principalTable: "FuneralBaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntity_FuneralEntity_FuneralId",
                        column: x => x.FuneralId,
                        principalTable: "FuneralEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntity_InstalEntity_InstalId",
                        column: x => x.InstalId,
                        principalTable: "InstalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntity_StandEntity_StandId",
                        column: x => x.StandId,
                        principalTable: "StandEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderEntity_StelaEntity_StelaId",
                        column: x => x.StelaId,
                        principalTable: "StelaEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeadModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    ThirdName = table.Column<string>(type: "TEXT", nullable: false),
                    Life = table.Column<string>(type: "TEXT", nullable: false),
                    Death = table.Column<string>(type: "TEXT", nullable: false),
                    OrderEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeadModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeadModel_OrderEntity_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "OrderEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_OrderEntity_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderEntity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItemComplectEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Procent = table.Column<int>(type: "INTEGER", nullable: false),
                    StateEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemComplectEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemComplectEntity_State_StateEntityId",
                        column: x => x.StateEntityId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Param1 = table.Column<string>(type: "TEXT", nullable: false),
                    Param2 = table.Column<string>(type: "TEXT", nullable: false),
                    StateEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_State_StateEntityId",
                        column: x => x.StateEntityId,
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeadModel_OrderEntityId",
                table: "DeadModel",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemComplectEntity_StateEntityId",
                table: "ItemComplectEntity",
                column: "StateEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_BaseId",
                table: "OrderEntity",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_ClientOrderId",
                table: "OrderEntity",
                column: "ClientOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_FlowershedId",
                table: "OrderEntity",
                column: "FlowershedId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_FuneralId",
                table: "OrderEntity",
                column: "FuneralId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_InstalId",
                table: "OrderEntity",
                column: "InstalId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_StandId",
                table: "OrderEntity",
                column: "StandId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderEntity_StelaId",
                table: "OrderEntity",
                column: "StelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_StateEntityId",
                table: "Service",
                column: "StateEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_State_OrderId",
                table: "State",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeadModel");

            migrationBuilder.DropTable(
                name: "ItemComplectEntity");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "OrderEntity");

            migrationBuilder.DropTable(
                name: "ClientOrderEntity");

            migrationBuilder.DropTable(
                name: "FlowershedEntity");

            migrationBuilder.DropTable(
                name: "FuneralBaseEntity");

            migrationBuilder.DropTable(
                name: "FuneralEntity");

            migrationBuilder.DropTable(
                name: "InstalEntity");

            migrationBuilder.DropTable(
                name: "StandEntity");

            migrationBuilder.DropTable(
                name: "StelaEntity");
        }
    }
}
