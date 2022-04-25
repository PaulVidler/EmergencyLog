using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyLog.Persistence.Migrations
{
    public partial class redefineRelationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ServiceOrganisations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "ServiceOrganisations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Organisations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "Organisations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ServiceOrganisations");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "ServiceOrganisations");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Organisations");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "Organisations");
        }
    }
}
