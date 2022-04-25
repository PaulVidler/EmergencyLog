using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class redefineRelationships1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_EmergencyContacts_EmergencyContactId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_EmergencyContactId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "EmergencyContactId",
                table: "Clients");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "EmergencyContacts",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContacts_ClientId",
                table: "EmergencyContacts",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmergencyContacts_Clients_ClientId",
                table: "EmergencyContacts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmergencyContacts_Clients_ClientId",
                table: "EmergencyContacts");

            migrationBuilder.DropIndex(
                name: "IX_EmergencyContacts_ClientId",
                table: "EmergencyContacts");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "EmergencyContacts");

            migrationBuilder.AddColumn<Guid>(
                name: "EmergencyContactId",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EmergencyContactId",
                table: "Clients",
                column: "EmergencyContactId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_EmergencyContacts_EmergencyContactId",
                table: "Clients",
                column: "EmergencyContactId",
                principalTable: "EmergencyContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
