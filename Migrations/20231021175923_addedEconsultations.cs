using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class addedEconsultations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 10, 21, 19, 59, 23, 851, DateTimeKind.Local).AddTicks(7773));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 10, 21, 19, 8, 14, 606, DateTimeKind.Local).AddTicks(9253));
        }
    }
}
