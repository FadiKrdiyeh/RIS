using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ris2022.Data.Migrations
{
    public partial class SecondCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "a00618d5-ef02-4f22-b500-1632a34d2300");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "7f0d9c03-8686-4006-8eab-f35b27b3bdfd");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ace7a300-ccfe-4acd-8880-c265812dea36");

            migrationBuilder.AddColumn<string>(
                name: "NationalIdNumber",
                table: "Patients",
                type: "NVARCHAR2(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ClinicId", "ConcurrencyStamp", "Departmentid", "Email", "EmailConfirmed", "Firstname", "Isdoctor", "Languageid", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "40bc12d1-d694-4c71-a82d-93f98113b42f", 0, null, "efd4e114-632c-480e-9621-21f71411973e", null, "RISAdmin@yy.com", true, "RIS", true, 1, "Admin", false, null, null, null, "P@ssw0rd123", null, true, "a35bdc90-7c21-419e-8758-a65eeaab9f52", false, "RISAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51ecc494-53b7-41b2-a986-1a770b053bb8", "7a3af335-9789-46ec-91bc-8ee8e096d98c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b205e3e6-9b6d-46ce-8a16-cdc9331a8e94", "45675193-f86f-4cfa-93de-57c925a83472", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "40bc12d1-d694-4c71-a82d-93f98113b42f");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "51ecc494-53b7-41b2-a986-1a770b053bb8");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "b205e3e6-9b6d-46ce-8a16-cdc9331a8e94");

            migrationBuilder.DropColumn(
                name: "NationalIdNumber",
                table: "Patients");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ClinicId", "ConcurrencyStamp", "Departmentid", "Email", "EmailConfirmed", "Firstname", "Isdoctor", "Languageid", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a00618d5-ef02-4f22-b500-1632a34d2300", 0, null, "79df72c5-d128-4b8f-9d5a-d74a17d22651", null, "RISAdmin@yy.com", true, "RIS", true, 1, "Admin", false, null, null, null, "P@ssw0rd123", null, true, "7f320699-f778-4d2e-bc68-6202a4be0da1", false, "RISAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7f0d9c03-8686-4006-8eab-f35b27b3bdfd", "c5627512-63eb-4371-bbfa-13b066fa86ca", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ace7a300-ccfe-4acd-8880-c265812dea36", "e43fdfb3-4814-4718-87b2-f963fe26f3c0", "User", "USER" });
        }
    }
}
