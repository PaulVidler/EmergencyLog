using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class redefineRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Addresses_AddressId",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Organisations_Addresses_AddressId",
                table: "Organisations");

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
                name: "FK_ServiceOrganisations_Addresses_AddressId",
                table: "ServiceOrganisations");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AddressId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_EmergencyContactId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "RelationshipEntityId",
                table: "EmergencyContacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "ServiceOrganisations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryContactId",
                table: "Properties",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
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
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Organisations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "EmergencyContacts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EmergencyContactId",
                table: "Clients",
                column: "EmergencyContactId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Addresses_AddressId",
                table: "EmergencyContacts",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Organisations_Addresses_AddressId",
                table: "Organisations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

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
                name: "FK_Properties_Organisations_OrganisationId",
                table: "Properties",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrganisations_Addresses_AddressId",
                table: "ServiceOrganisations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Addresses_AddressId",
                table: "EmergencyContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Organisations_Addresses_AddressId",
                table: "Organisations");

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
                name: "FK_ServiceOrganisations_Addresses_AddressId",
                table: "ServiceOrganisations");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AddressId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_EmergencyContactId",
                table: "Clients");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "ServiceOrganisations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

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
                name: "OrganisationId",
                table: "Properties",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Properties",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Organisations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "EmergencyContacts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RelationshipEntityId",
                table: "EmergencyContacts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EmergencyContactId",
                table: "Clients",
                column: "EmergencyContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Organisations_OrganisationId",
                table: "Clients",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Addresses_AddressId",
                table: "EmergencyContacts",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organisations_Addresses_AddressId",
                table: "Organisations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
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
                name: "FK_ServiceOrganisations_Addresses_AddressId",
                table: "ServiceOrganisations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
