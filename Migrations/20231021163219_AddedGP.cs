using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class AddedGP : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_GP_GPId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GP",
                table: "GP");

            migrationBuilder.RenameTable(
                name: "GP",
                newName: "GPs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GPs",
                table: "GPs",
                column: "GPId");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 10, 21, 18, 32, 19, 594, DateTimeKind.Local).AddTicks(8280));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_GPs_GPId",
                table: "Appointments",
                column: "GPId",
                principalTable: "GPs",
                principalColumn: "GPId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_GPs_GPId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GPs",
                table: "GPs");

            migrationBuilder.RenameTable(
                name: "GPs",
                newName: "GP");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GP",
                table: "GP",
                column: "GPId");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 10, 21, 17, 51, 59, 46, DateTimeKind.Local).AddTicks(2316));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_GP_GPId",
                table: "Appointments",
                column: "GPId",
                principalTable: "GP",
                principalColumn: "GPId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
