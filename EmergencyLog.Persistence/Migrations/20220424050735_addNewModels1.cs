using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class addNewModels1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguishers_ServiceOrganisation_ServicedOrganisationId",
                table: "FireExtinguishers");

            migrationBuilder.DropForeignKey(
                name: "FK_FireHoses_ServiceOrganisation_ServicedOrganisationId",
                table: "FireHoses");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrganisation_Addresses_AddressId",
                table: "ServiceOrganisation");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrganisation_Clients_PrimaryContactId",
                table: "ServiceOrganisation");

            migrationBuilder.DropForeignKey(
                name: "FK_SmokeAlarms_ServiceOrganisation_ServicedOrganisationId",
                table: "SmokeAlarms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrganisation",
                table: "ServiceOrganisation");

            migrationBuilder.RenameTable(
                name: "ServiceOrganisation",
                newName: "ServiceOrganisations");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrganisation_PrimaryContactId",
                table: "ServiceOrganisations",
                newName: "IX_ServiceOrganisations_PrimaryContactId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrganisation_AddressId",
                table: "ServiceOrganisations",
                newName: "IX_ServiceOrganisations_AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Organisations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrganisations",
                table: "ServiceOrganisations",
                column: "ServiceOrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguishers_ServiceOrganisations_ServicedOrganisationId",
                table: "FireExtinguishers",
                column: "ServicedOrganisationId",
                principalTable: "ServiceOrganisations",
                principalColumn: "ServiceOrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireHoses_ServiceOrganisations_ServicedOrganisationId",
                table: "FireHoses",
                column: "ServicedOrganisationId",
                principalTable: "ServiceOrganisations",
                principalColumn: "ServiceOrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrganisations_Addresses_AddressId",
                table: "ServiceOrganisations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrganisations_Clients_PrimaryContactId",
                table: "ServiceOrganisations",
                column: "PrimaryContactId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmokeAlarms_ServiceOrganisations_ServicedOrganisationId",
                table: "SmokeAlarms",
                column: "ServicedOrganisationId",
                principalTable: "ServiceOrganisations",
                principalColumn: "ServiceOrganisationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_FireExtinguishers_ServiceOrganisations_ServicedOrganisationId",
                table: "FireExtinguishers");

            migrationBuilder.DropForeignKey(
                name: "FK_FireHoses_ServiceOrganisations_ServicedOrganisationId",
                table: "FireHoses");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrganisations_Addresses_AddressId",
                table: "ServiceOrganisations");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrganisations_Clients_PrimaryContactId",
                table: "ServiceOrganisations");

            migrationBuilder.DropForeignKey(
                name: "FK_SmokeAlarms_ServiceOrganisations_ServicedOrganisationId",
                table: "SmokeAlarms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrganisations",
                table: "ServiceOrganisations");

            migrationBuilder.RenameTable(
                name: "ServiceOrganisations",
                newName: "ServiceOrganisation");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrganisations_PrimaryContactId",
                table: "ServiceOrganisation",
                newName: "IX_ServiceOrganisation_PrimaryContactId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrganisations_AddressId",
                table: "ServiceOrganisation",
                newName: "IX_ServiceOrganisation_AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Organisations",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrganisation",
                table: "ServiceOrganisation",
                column: "ServiceOrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireExtinguishers_ServiceOrganisation_ServicedOrganisationId",
                table: "FireExtinguishers",
                column: "ServicedOrganisationId",
                principalTable: "ServiceOrganisation",
                principalColumn: "ServiceOrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FireHoses_ServiceOrganisation_ServicedOrganisationId",
                table: "FireHoses",
                column: "ServicedOrganisationId",
                principalTable: "ServiceOrganisation",
                principalColumn: "ServiceOrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrganisation_Addresses_AddressId",
                table: "ServiceOrganisation",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrganisation_Clients_PrimaryContactId",
                table: "ServiceOrganisation",
                column: "PrimaryContactId",
                principalTable: "Clients",
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
    }
}
