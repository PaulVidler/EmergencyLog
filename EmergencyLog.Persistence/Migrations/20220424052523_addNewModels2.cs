using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class addNewModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrganisations_Clients_PrimaryContactId",
                table: "ServiceOrganisations");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryContactId",
                table: "ServiceOrganisations",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrganisations_Clients_PrimaryContactId",
                table: "ServiceOrganisations",
                column: "PrimaryContactId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrganisations_Clients_PrimaryContactId",
                table: "ServiceOrganisations");

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryContactId",
                table: "ServiceOrganisations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrganisations_Clients_PrimaryContactId",
                table: "ServiceOrganisations",
                column: "PrimaryContactId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
