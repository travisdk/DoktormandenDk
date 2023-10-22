using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class newdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 11, 11, 9, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "AppointmentMessage", "AppointmentTime", "Category", "GPId", "PatientId" },
                values: new object[] { 2, "Smerter i lysken når jeg bukker mig ned, venstre side", new DateTime(2023, 11, 11, 9, 30, 0, 0, DateTimeKind.Unspecified), 0, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 10, 22, 11, 40, 24, 922, DateTimeKind.Local).AddTicks(2319));
        }
    }
}
