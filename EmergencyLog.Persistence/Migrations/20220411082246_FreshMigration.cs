using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class FreshMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Mobile = table.Column<string>(type: "TEXT", nullable: true),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    ImageSmall = table.Column<string>(type: "TEXT", nullable: true),
                    ImageLarge = table.Column<string>(type: "TEXT", nullable: true),
                    RelationshipType = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_Entity_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StreetNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    Suburb = table.Column<string>(type: "TEXT", nullable: true),
                    Postcode = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Entity_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TimeIn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeOut = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OnSite = table.Column<bool>(type: "INTEGER", nullable: false),
                    EntryComplete = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendances_Entity_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EntityId",
                table: "Addresses",
                column: "EntityId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ClientId",
                table: "Attendances",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_ClientId",
                table: "Entity",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Entity");
        }
    }
}
