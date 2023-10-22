using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class ChangedAppointmentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "AppointmentMessage",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Appointments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                columns: new[] { "AppointmentMessage", "AppointmentTime", "Category" },
                values: new object[] { "Hul i hovedet", new DateTime(2023, 10, 22, 11, 40, 24, 922, DateTimeKind.Local).AddTicks(2319), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentMessage",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Appointments");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                columns: new[] { "AppointmentTime", "Subject" },
                values: new object[] { new DateTime(2023, 10, 21, 20, 9, 16, 387, DateTimeKind.Local).AddTicks(5084), "Hul i hovedet" });
        }
    }
}
