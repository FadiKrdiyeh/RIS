using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ris2022.Data.Migrations
{
    public partial class ForthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "2d1c98be-7d43-44a5-905b-8b9c620f4f8a");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "27941722-da70-4c04-bbc7-ea5ff26769bd");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "482cacb2-0d19-4e7f-8bed-741e70567076");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ClinicId", "ConcurrencyStamp", "Departmentid", "Email", "EmailConfirmed", "Firstname", "Isdoctor", "Languageid", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d70af375-f4ff-4b02-8603-7be4fad3a7e3", 0, null, "b6c42d46-b7f1-4c3b-803d-f44f5417a222", null, "RISAdmin@yy.com", true, "RIS", true, 1, "Admin", false, null, null, null, "P@ssw0rd123", null, true, "ad50170a-9462-4703-974b-72e39f8a9b3d", false, "RISAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc092175-5555-477e-93e7-8d7bab11573c", "9348df50-637d-4602-a97f-fa7ae1ed5494", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d7dee8bd-f7b4-4e7c-8287-4281ed284f59", "16e3bf6a-3515-4b0d-99a0-5df25cee668d", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "d70af375-f4ff-4b02-8603-7be4fad3a7e3");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "cc092175-5555-477e-93e7-8d7bab11573c");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "d7dee8bd-f7b4-4e7c-8287-4281ed284f59");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ClinicId", "ConcurrencyStamp", "Departmentid", "Email", "EmailConfirmed", "Firstname", "Isdoctor", "Languageid", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2d1c98be-7d43-44a5-905b-8b9c620f4f8a", 0, null, "50b98ca3-2da3-4b98-87ab-833efec3ac0f", null, "RISAdmin@yy.com", true, "RIS", true, 1, "Admin", false, null, null, null, "P@ssw0rd123", null, true, "9b61967e-656e-49c1-8b64-1833b8d79e3e", false, "RISAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "27941722-da70-4c04-bbc7-ea5ff26769bd", "fea56e18-5a87-4a55-8d64-00a23bfc0d47", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "482cacb2-0d19-4e7f-8bed-741e70567076", "bc6fc8f9-dc98-46c3-83c4-968ebe81219d", "User", "USER" });
        }
    }
}
