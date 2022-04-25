using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class redefineRelationships13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Clients_ClientId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Organisations_OrganisationId",
                table: "Properties");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganisationId",
                table: "Properties",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "Attendances",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Clients_ClientId",
                table: "Attendances",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Organisations_OrganisationId",
                table: "Properties",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Clients_ClientId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Organisations_OrganisationId",
                table: "Properties");

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
                name: "ClientId",
                table: "Attendances",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Clients_ClientId",
                table: "Attendances",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Organisations_OrganisationId",
                table: "Properties",
                column: "OrganisationId",
                principalTable: "Organisations",
                principalColumn: "OrganisationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
