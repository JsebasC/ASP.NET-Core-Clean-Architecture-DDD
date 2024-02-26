using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Identity.Migrations
{
    public partial class Actualizarnombredrol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07655f71-90c3-445c-9bb4-983463cea466",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "11ef3b79-6389-4414-9597-ae4e9fa71aa5", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "945a3c35-89c1-4b90-b485-14319378b702",
                column: "ConcurrencyStamp",
                value: "1365f8d9-c3d1-4cc0-ba61-a7538565db61");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "28ad3b37-c788-4930-b3f8-9d06c1d59ae6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18a13f6a-3345-4be3-abca-395120e33f29", "AQAAAAEAACcQAAAAEMFrfabBoxdTeM/Xl9z/gNfQ2iBzLP3U3vVzXeO/Udp5pKdzAg2Q16dx/2ttBEDDww==", "635d1a7e-e4f7-4f13-8e13-399d787e2de0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3af526db-b8be-4e87-9639-5bd9b93c880e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "099e48d5-fadc-4d72-87ca-6b26f7692506", "AQAAAAEAACcQAAAAEP0kZ9CxHVTe6AY2lyy0a8hGbuJdFnoZnUG8F8ukF5HrW+cLyzy7n3gJvsegVPKVcg==", "3f27a6b7-82dd-47bc-a373-8b08b03b1085" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07655f71-90c3-445c-9bb4-983463cea466",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "309a1697-03d2-49d8-986b-90aa2a28b361", "ADMINSITRATOR" });

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
    }
}
