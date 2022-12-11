using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ris2022.Data.Migrations
{
    public partial class FifthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "NationalIdNumber",
                table: "Patients",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<int>(
                name: "Gendre",
                table: "Patients",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "NationalIdNumber",
                table: "Patients",
                type: "NVARCHAR2(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.AlterColumn<int>(
                name: "Gendre",
                table: "Patients",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

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
    }
}
