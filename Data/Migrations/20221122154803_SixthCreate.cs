using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ris2022.Data.Migrations
{
    public partial class SixthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "602acb02-e038-4ffe-8191-87927668c6f2");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "91d19b9b-9f1d-4e82-8281-6aa3c441da0e");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "ac1835c3-d864-4665-9a36-f7870c73a4a9");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ClinicId", "ConcurrencyStamp", "Departmentid", "Email", "EmailConfirmed", "Firstname", "Isdoctor", "Languageid", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "369a50a5-a20c-48cc-ac10-d8cb244a70fb", 0, null, "fa846b63-4f07-459d-b476-a65a545444d3", null, "RISAdmin@yy.com", true, "RIS", true, 1, "Admin", false, null, null, null, "P@ssw0rd123", null, true, "8f1f9051-d8cc-4687-946b-2f95b55d4f18", false, "RISAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "723c8787-0df7-4eb6-8984-4749976bca43", "c16d260e-f2e2-45a7-a5d0-ecacd1489ebc", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a2cb6ad2-195e-49f2-8a8d-bc5fe2dfd644", "d4caca49-c7c6-44d3-aa1c-3108eebfc356", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUser",
                keyColumn: "Id",
                keyValue: "369a50a5-a20c-48cc-ac10-d8cb244a70fb");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "723c8787-0df7-4eb6-8984-4749976bca43");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "a2cb6ad2-195e-49f2-8a8d-bc5fe2dfd644");

            migrationBuilder.InsertData(
                table: "AppUser",
                columns: new[] { "Id", "AccessFailedCount", "ClinicId", "ConcurrencyStamp", "Departmentid", "Email", "EmailConfirmed", "Firstname", "Isdoctor", "Languageid", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "602acb02-e038-4ffe-8191-87927668c6f2", 0, null, "e3e09089-8c03-4417-b86a-3c772a9ecc7c", null, "RISAdmin@yy.com", true, "RIS", true, 1, "Admin", false, null, null, null, "P@ssw0rd123", null, true, "dfbe4569-677a-4645-8f8b-71fa7682a2e5", false, "RISAdmin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "91d19b9b-9f1d-4e82-8281-6aa3c441da0e", "30db3016-e860-411a-be73-9432a9bdaa5e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ac1835c3-d864-4665-9a36-f7870c73a4a9", "4a9153d2-e2f3-4dca-bd5b-85cf7716fbb2", "User", "USER" });
        }
    }
}
