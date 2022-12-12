using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ris2022.Data.Migrations
{
    public partial class EightthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "4214991e-b734-404a-b499-8642398140f9");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "2ed31163-adf4-47e7-8e76-533a24607ba8");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "92131b18-48cd-49b8-b04c-94f065e7555f");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ClinicId", "ConcurrencyStamp", "Departmentid", "Email", "EmailConfirmed", "Firstname", "Isdoctor", "Languageid", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2fc1ecf9-571e-43e2-ae89-31a34bd391ba", 0, null, "8e0c92ca-3c76-4694-a8c8-fbe177fa4898", null, "RISAdmin@yy.com", true, "RIS", true, 1, "Admin", false, null, null, null, "P@ssw0rd123", null, true, "93f53403-f09f-4dd5-807a-1493bcbe6553", false, "RISAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ff897b9-ae2b-4143-98ec-a22c33e80e84", "744779a2-1b0b-45b6-934d-5bd43d4e9fc3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "98529f63-55e0-4885-9400-8e3b3d90c565", "d83035ee-f95c-412f-85f0-15b7a50e48b1", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "2fc1ecf9-571e-43e2-ae89-31a34bd391ba");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "2ff897b9-ae2b-4143-98ec-a22c33e80e84");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "98529f63-55e0-4885-9400-8e3b3d90c565");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ClinicId", "ConcurrencyStamp", "Departmentid", "Email", "EmailConfirmed", "Firstname", "Isdoctor", "Languageid", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "4214991e-b734-404a-b499-8642398140f9", 0, null, "240ba578-952a-40e7-8a03-251b93bd276c", null, "RISAdmin@yy.com", true, "RIS", true, 1, "Admin", false, null, null, null, "P@ssw0rd123", null, true, "cb1203a1-ed17-407e-b17c-36dc4b974b79", false, "RISAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2ed31163-adf4-47e7-8e76-533a24607ba8", "772b3648-ea71-42af-9254-451ccd61827b", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "92131b18-48cd-49b8-b04c-94f065e7555f", "2867b1e0-3fb2-4584-89a6-cfef3424ba18", "User", "USER" });
        }
    }
}
