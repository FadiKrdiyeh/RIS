using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ris2022.Data.Migrations
{
    public partial class SeventhCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Payreasonid",
                table: "Orders",
                type: "NVARCHAR2(2000)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Payreasonid",
                table: "Orders",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)",
                oldNullable: true);

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
    }
}
