using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StreetNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    Suburb = table.Column<string>(type: "TEXT", nullable: true),
                    Postcode = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RelationshipType = table.Column<int>(type: "INTEGER", nullable: false),
                    RelationshipEntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Mobile = table.Column<string>(type: "TEXT", nullable: true),
                    AddressId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyContacts_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
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
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ImageSmall = table.Column<string>(type: "TEXT", nullable: true),
                    ImageLarge = table.Column<string>(type: "TEXT", nullable: true),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    AddressId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmergencyContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrganisationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    Mobile = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_EmergencyContacts_EmergencyContactId",
                        column: x => x.EmergencyContactId,
                        principalTable: "EmergencyContacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organisations",
                columns: table => new
                {
                    OrganisationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrganisationName = table.Column<string>(type: "TEXT", nullable: false),
                    Logo = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddressId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisations", x => x.OrganisationId);
                    table.ForeignKey(
                        name: "FK_Organisations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Organisations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddressId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PrimaryContactId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Properties_Clients_PrimaryContactId",
                        column: x => x.PrimaryContactId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FireExtinguishers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EquipmentType = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    LastServiced = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NextService = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ServicedByOrganisationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PropertyId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireExtinguishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireExtinguishers_Organisations_ServicedByOrganisationId",
                        column: x => x.ServicedByOrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId");
                    table.ForeignKey(
                        name: "FK_FireExtinguishers_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FireHoses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EquipmentType = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    LastServiced = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NextService = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ServicedByOrganisationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PropertyId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireHoses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireHoses_Organisations_ServicedByOrganisationId",
                        column: x => x.ServicedByOrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId");
                    table.ForeignKey(
                        name: "FK_FireHoses_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SmokeAlarms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    EquipmentType = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    LastServiced = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NextService = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ServicedByOrganisationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PropertyId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmokeAlarms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmokeAlarms_Organisations_ServicedByOrganisationId",
                        column: x => x.ServicedByOrganisationId,
                        principalTable: "Organisations",
                        principalColumn: "OrganisationId");
                    table.ForeignKey(
                        name: "FK_SmokeAlarms_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_ClientId",
                table: "Attendances",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EmergencyContactId",
                table: "Clients",
                column: "EmergencyContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_OrganisationId",
                table: "Clients",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_AddressId",
                table: "EmergencyContacts",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguishers_PropertyId",
                table: "FireExtinguishers",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguishers_ServicedByOrganisationId",
                table: "FireExtinguishers",
                column: "ServicedByOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_FireHoses_PropertyId",
                table: "FireHoses",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_FireHoses_ServicedByOrganisationId",
                table: "FireHoses",
                column: "ServicedByOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_AddressId",
                table: "Organisations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_ClientId",
                table: "Organisations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_AddressId",
                table: "Properties",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PrimaryContactId",
                table: "Properties",
                column: "PrimaryContactId");

            migrationBuilder.CreateIndex(
                name: "IX_SmokeAlarms_PropertyId",
                table: "SmokeAlarms",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_SmokeAlarms_ServicedByOrganisationId",
                table: "SmokeAlarms",
                column: "ServicedByOrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Clients_ClientId",
                table: "Attendances",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organisations_Clients_ClientId",
                table: "Organisations");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "FireExtinguishers");

            migrationBuilder.DropTable(
                name: "FireHoses");

            migrationBuilder.DropTable(
                name: "SmokeAlarms");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "EmergencyContacts");

            migrationBuilder.DropTable(
                name: "Organisations");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
