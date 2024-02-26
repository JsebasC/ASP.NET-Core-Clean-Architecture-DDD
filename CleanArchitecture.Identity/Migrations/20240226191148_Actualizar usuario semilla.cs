using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Identity.Migrations
{
    public partial class Actualizarusuariosemilla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07655f71-90c3-445c-9bb4-983463cea466",
                column: "ConcurrencyStamp",
                value: "309a1697-03d2-49d8-986b-90aa2a28b361");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "945a3c35-89c1-4b90-b485-14319378b702",
                column: "ConcurrencyStamp",
                value: "2e66fb5e-6588-4f69-af34-9d621fa7e7ab");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28ad3b37-c788-4930-b3f8-9d06c1d59ae6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c58d20ba-c580-41a5-a51f-42a845cd6d93", "AQAAAAEAACcQAAAAEAqK0Y2Hkh6MQGB8d4XdB85tuwVUxMZPJjX6CqaAcUTolwfHTJApSI2G1vFAa2SPLA==", "be1e4772-ea0c-4ad6-8e18-12fdb67b5e9d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3af526db-b8be-4e87-9639-5bd9b93c880e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdacc406-0ff0-4625-a3d0-99e8766379cc", "AQAAAAEAACcQAAAAEOkNQwIlX0heQxeBlMHyG7gOfsruGp+bawus1pssEl+X8AYTJPEgHlY8X4eYxLCTIg==", "78754fb4-2c5d-4f8b-97b3-18f0a96398a5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07655f71-90c3-445c-9bb4-983463cea466",
                column: "ConcurrencyStamp",
                value: "bb7435a3-b04c-4815-8a66-bf34cb1617ef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "945a3c35-89c1-4b90-b485-14319378b702",
                column: "ConcurrencyStamp",
                value: "1d46f4c7-94d1-447e-abaf-88056d89a5c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28ad3b37-c788-4930-b3f8-9d06c1d59ae6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "598ae8a0-7564-4fd6-bf9f-865d400296de", "AQAAAAEAACcQAAAAEAc2HpIAsMVpl2fAVtTKxn61G65E6Yg0tsJ0HIho0nXXfzzGp95EoRB156JsUxMu0g==", "d7c0f62c-8e0d-4acb-9e3a-593ac4a4fd18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3af526db-b8be-4e87-9639-5bd9b93c880e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26bd9016-de0d-48eb-93fc-70ac93ea5e56", "AQAAAAEAACcQAAAAELMXQ5H2oLfwLVYB/OUaWOAz5LRMuuZ4Zs1eKeCXI9Xb2Jm2wvLiLh2j7UR6z+STog==", "22287cc6-d1f2-4179-a816-5838b180fdcd" });
        }
    }
}
