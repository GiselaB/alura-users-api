using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuariosAPI.Migrations
{
    public partial class Adicionandocustomidentityuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "4c398506-e328-4730-b154-f161f32020b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "00ab66bb-d9de-4eed-aaa6-5808ac90dd71");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5d3441e-4ef7-4650-ac5f-6737392ac3b7", "AQAAAAEAACcQAAAAENqZ7COz8AKM3kV4hQX2WmneEzgPGlA9lMgqfxEI+zEApyexFwECJbEB/MrUtkK5BA==", "40db8e04-2b8f-4b4a-8ee4-5bef1e8f3b09" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99997,
                column: "ConcurrencyStamp",
                value: "a57332e1-319e-4617-8b03-4b16c657b0e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "330d36ca-d467-4759-b50a-d909c208ebbb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e84c0f08-5db3-479e-a8d4-d6f7aa7387ba", "AQAAAAEAACcQAAAAEEKTU/0u1xWLrS1lrIgFph9BUQGJoBtpGpkjPx1x1ndNSaLs/SYeDYilaUnrCi3ikQ==", "e24d5dfe-3ba2-4bfa-be42-32ba734a9231" });
        }
    }
}
