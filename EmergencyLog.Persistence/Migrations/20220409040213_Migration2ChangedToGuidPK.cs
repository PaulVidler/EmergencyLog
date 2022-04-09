using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class Migration2ChangedToGuidPK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Entity_EntityId",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Entity_EmergencyContactId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Addresses_AddressId",
                table: "Entity");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Entity_EntityRelationshipId",
                table: "Entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entity",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_AddressId",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_EntityRelationshipId",
                table: "Entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AddressId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_EmergencyContactId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_EntityId",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "EmergencyContactId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Addresses");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressGuid",
                table: "Entity",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AddressGuid",
                table: "Clients",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmergencyContactGuid",
                table: "Clients",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EntityGuid",
                table: "Attendances",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entity",
                table: "Entity",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Guid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Guid");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_AddressGuid",
                table: "Entity",
                column: "AddressGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressGuid",
                table: "Clients",
                column: "AddressGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EmergencyContactGuid",
                table: "Clients",
                column: "EmergencyContactGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EntityGuid",
                table: "Attendances",
                column: "EntityGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Entity_EntityGuid",
                table: "Attendances",
                column: "EntityGuid",
                principalTable: "Entity",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_AddressGuid",
                table: "Clients",
                column: "AddressGuid",
                principalTable: "Addresses",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Entity_EmergencyContactGuid",
                table: "Clients",
                column: "EmergencyContactGuid",
                principalTable: "Entity",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Addresses_AddressGuid",
                table: "Entity",
                column: "AddressGuid",
                principalTable: "Addresses",
                principalColumn: "Guid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Entity_EntityGuid",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_AddressGuid",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Entity_EmergencyContactGuid",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Entity_Addresses_AddressGuid",
                table: "Entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entity",
                table: "Entity");

            migrationBuilder.DropIndex(
                name: "IX_Entity_AddressGuid",
                table: "Entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_AddressGuid",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_EmergencyContactGuid",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_EntityGuid",
                table: "Attendances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressGuid",
                table: "Entity");

            migrationBuilder.DropColumn(
                name: "AddressGuid",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "EmergencyContactGuid",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "EntityGuid",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Entity",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Entity",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Mobile",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Clients",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmergencyContactId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "Attendances",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Addresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entity",
                table: "Entity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_AddressId",
                table: "Entity",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_EntityRelationshipId",
                table: "Entity",
                column: "EntityRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_EmergencyContactId",
                table: "Clients",
                column: "EmergencyContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EntityId",
                table: "Attendances",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Entity_EntityId",
                table: "Attendances",
                column: "EntityId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Entity_EmergencyContactId",
                table: "Clients",
                column: "EmergencyContactId",
                principalTable: "Entity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Addresses_AddressId",
                table: "Entity",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entity_Entity_EntityRelationshipId",
                table: "Entity",
                column: "EntityRelationshipId",
                principalTable: "Entity",
                principalColumn: "Id");
        }
    }
}
