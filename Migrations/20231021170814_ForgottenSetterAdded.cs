using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class ForgottenSetterAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 10, 21, 19, 8, 14, 606, DateTimeKind.Local).AddTicks(9253));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 10, 21, 18, 32, 19, 594, DateTimeKind.Local).AddTicks(8280));
        }
    }
}
