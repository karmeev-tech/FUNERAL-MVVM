using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations.Issue
{
    /// <inheritdoc />
    public partial class mig5 : Migration
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
                name: "IssueComplect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueComplect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueMoney",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueMoney", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
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
                name: "ItemComplectEntity",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    Money = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Procent = table.Column<int>(type: "INTEGER", nullable: false),
                    ItemsComplectEFentityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemComplectEntity", x => x.Name);
                    table.ForeignKey(
                        name: "FK_ItemComplectEntity_IssueComplect_ItemsComplectEFentityId",
                        column: x => x.ItemsComplectEFentityId,
                        principalTable: "IssueComplect",
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
                    ServiceComplectEFentityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Services_ServiceComplectEFentityId",
                        column: x => x.ServiceComplectEFentityId,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "IssueOrder",
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
                    table.PrimaryKey("PK_IssueOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueOrder_ClientOrderEntity_ClientOrderId",
                        column: x => x.ClientOrderId,
                        principalTable: "ClientOrderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueOrder_FlowershedEntity_FlowershedId",
                        column: x => x.FlowershedId,
                        principalTable: "FlowershedEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueOrder_FuneralBaseEntity_BaseId",
                        column: x => x.BaseId,
                        principalTable: "FuneralBaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueOrder_FuneralEntity_FuneralId",
                        column: x => x.FuneralId,
                        principalTable: "FuneralEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueOrder_InstalEntity_InstalId",
                        column: x => x.InstalId,
                        principalTable: "InstalEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueOrder_StandEntity_StandId",
                        column: x => x.StandId,
                        principalTable: "StandEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueOrder_StelaEntity_StelaId",
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
                        name: "FK_DeadModel_IssueOrder_OrderEntityId",
                        column: x => x.OrderEntityId,
                        principalTable: "IssueOrder",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeadModel_OrderEntityId",
                table: "DeadModel",
                column: "OrderEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueOrder_BaseId",
                table: "IssueOrder",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueOrder_ClientOrderId",
                table: "IssueOrder",
                column: "ClientOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueOrder_FlowershedId",
                table: "IssueOrder",
                column: "FlowershedId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueOrder_FuneralId",
                table: "IssueOrder",
                column: "FuneralId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueOrder_InstalId",
                table: "IssueOrder",
                column: "InstalId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueOrder_StandId",
                table: "IssueOrder",
                column: "StandId");

            migrationBuilder.CreateIndex(
                name: "IX_IssueOrder_StelaId",
                table: "IssueOrder",
                column: "StelaId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemComplectEntity_ItemsComplectEFentityId",
                table: "ItemComplectEntity",
                column: "ItemsComplectEFentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceComplectEFentityId",
                table: "Service",
                column: "ServiceComplectEFentityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeadModel");

            migrationBuilder.DropTable(
                name: "IssueMoney");

            migrationBuilder.DropTable(
                name: "ItemComplectEntity");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "IssueOrder");

            migrationBuilder.DropTable(
                name: "IssueComplect");

            migrationBuilder.DropTable(
                name: "Services");

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
