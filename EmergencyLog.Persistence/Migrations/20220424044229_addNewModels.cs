using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class addNewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguishers_Organisations_ServicedByOrganisationId",
                table: "FireExtinguishers");

            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguishers_Properties_PropertyId",
                table: "FireExtinguishers");

            migrationBuilder.DropForeignKey(
                name: "FK_FireHoses_Organisations_ServicedByOrganisationId",
                table: "FireHoses");

            migrationBuilder.DropForeignKey(
                name: "FK_FireHoses_Properties_PropertyId",
                table: "FireHoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Organisations_Clients_ClientId",
                table: "Organisations");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Clients_PrimaryContactId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_SmokeAlarms_Organisations_ServicedByOrganisationId",
                table: "SmokeAlarms");

            migrationBuilder.DropForeignKey(
                name: "FK_SmokeAlarms_Properties_PropertyId",
                table: "SmokeAlarms");

            migrationBuilder.DropIndex(
                name: "IX_SmokeAlarms_ServicedByOrganisationId",
                table: "SmokeAlarms");

            migrationBuilder.DropIndex(
                name: "IX_Organisations_ClientId",
                table: "Organisations");

            migrationBuilder.DropIndex(
                name: "IX_FireHoses_ServicedByOrganisationId",
                table: "FireHoses");

            migrationBuilder.DropIndex(
                name: "IX_FireExtinguishers_ServicedByOrganisationId",
                table: "FireExtinguishers");

            migrationBuilder.DropColumn(
                name: "ServicedByOrganisationId",
                table: "SmokeAlarms");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "ServicedByOrganisationId",
                table: "FireHoses");

            migrationBuilder.DropColumn(
                name: "ServicedByOrganisationId",
                table: "FireExtinguishers");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "SmokeAlarms",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServicedOrganisationId",
                table: "SmokeAlarms",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryContactId",
                table: "Properties",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Properties",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrganisationId",
                table: "Properties",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "FireHoses",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServicedOrganisationId",
                table: "FireHoses",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "FireExtinguishers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServicedOrganisationId",
                table: "FireExtinguishers",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceOrganisation",
                columns: table => new
                {
                    ServiceOrganisationId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ServiceOrganisationName = table.Column<string>(type: "TEXT", nullable: true),
                    Logo = table.Column<string>(type: "TEXT", nullable: true),
                    PrimaryContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddressId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrganisation", x => x.ServiceOrganisationId);
                    table.ForeignKey(
                        name: "FK_ServiceOrganisation_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrganisation_Clients_PrimaryContactId",
                        column: x => x.PrimaryContactId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmokeAlarms_ServicedOrganisationId",
                table: "SmokeAlarms",
                column: "ServicedOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_OrganisationId",
                table: "Properties",
                column: "OrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_FireHoses_ServicedOrganisationId",
                table: "FireHoses",
                column: "ServicedOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguishers_ServicedOrganisationId",
                table: "FireExtinguishers",
                column: "ServicedOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrganisation_AddressId",
                table: "ServiceOrganisation",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrganisation_PrimaryContactId",
                table: "ServiceOrganisation",
                column: "PrimaryContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguishers_Properties_PropertyId",
                table: "FireExtinguishers",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguishers_ServiceOrganisation_ServicedOrganisationId",
                table: "FireExtinguishers",
                column: "ServicedOrganisationId",
                principalTable: "ServiceOrganisation",
                principalColumn: "ServiceOrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireHoses_Properties_PropertyId",
                table: "FireHoses",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireHoses_ServiceOrganisation_ServicedOrganisationId",
                table: "FireHoses",
                column: "ServicedOrganisationId",
                principalTable: "ServiceOrganisation",
                principalColumn: "ServiceOrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Clients_PrimaryContactId",
                table: "Properties",
                column: "PrimaryContactId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Organisations_OrganisationId",
                table: "Properties",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SmokeAlarms_Properties_PropertyId",
                table: "SmokeAlarms",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmokeAlarms_ServiceOrganisation_ServicedOrganisationId",
                table: "SmokeAlarms",
                column: "ServicedOrganisationId",
                principalTable: "ServiceOrganisation",
                principalColumn: "ServiceOrganisationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguishers_Properties_PropertyId",
                table: "FireExtinguishers");

            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguishers_ServiceOrganisation_ServicedOrganisationId",
                table: "FireExtinguishers");

            migrationBuilder.DropForeignKey(
                name: "FK_FireHoses_Properties_PropertyId",
                table: "FireHoses");

            migrationBuilder.DropForeignKey(
                name: "FK_FireHoses_ServiceOrganisation_ServicedOrganisationId",
                table: "FireHoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Clients_PrimaryContactId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Organisations_OrganisationId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_SmokeAlarms_Properties_PropertyId",
                table: "SmokeAlarms");

            migrationBuilder.DropForeignKey(
                name: "FK_SmokeAlarms_ServiceOrganisation_ServicedOrganisationId",
                table: "SmokeAlarms");

            migrationBuilder.DropTable(
                name: "ServiceOrganisation");

            migrationBuilder.DropIndex(
                name: "IX_SmokeAlarms_ServicedOrganisationId",
                table: "SmokeAlarms");

            migrationBuilder.DropIndex(
                name: "IX_Properties_OrganisationId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_FireHoses_ServicedOrganisationId",
                table: "FireHoses");

            migrationBuilder.DropIndex(
                name: "IX_FireExtinguishers_ServicedOrganisationId",
                table: "FireExtinguishers");

            migrationBuilder.DropColumn(
                name: "ServicedOrganisationId",
                table: "SmokeAlarms");

            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ServicedOrganisationId",
                table: "FireHoses");

            migrationBuilder.DropColumn(
                name: "ServicedOrganisationId",
                table: "FireExtinguishers");

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "SmokeAlarms",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "ServicedByOrganisationId",
                table: "SmokeAlarms",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryContactId",
                table: "Properties",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Properties",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Organisations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "FireHoses",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "ServicedByOrganisationId",
                table: "FireHoses",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PropertyId",
                table: "FireExtinguishers",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddColumn<Guid>(
                name: "ServicedByOrganisationId",
                table: "FireExtinguishers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_SmokeAlarms_ServicedByOrganisationId",
                table: "SmokeAlarms",
                column: "ServicedByOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organisations_ClientId",
                table: "Organisations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_FireHoses_ServicedByOrganisationId",
                table: "FireHoses",
                column: "ServicedByOrganisationId");

            migrationBuilder.CreateIndex(
                name: "IX_FireExtinguishers_ServicedByOrganisationId",
                table: "FireExtinguishers",
                column: "ServicedByOrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguishers_Organisations_ServicedByOrganisationId",
                table: "FireExtinguishers",
                column: "ServicedByOrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguishers_Properties_PropertyId",
                table: "FireExtinguishers",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FireHoses_Organisations_ServicedByOrganisationId",
                table: "FireHoses",
                column: "ServicedByOrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireHoses_Properties_PropertyId",
                table: "FireHoses",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organisations_Clients_ClientId",
                table: "Organisations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Addresses_AddressId",
                table: "Properties",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Clients_PrimaryContactId",
                table: "Properties",
                column: "PrimaryContactId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SmokeAlarms_Organisations_ServicedByOrganisationId",
                table: "SmokeAlarms",
                column: "ServicedByOrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_SmokeAlarms_Properties_PropertyId",
                table: "SmokeAlarms",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
