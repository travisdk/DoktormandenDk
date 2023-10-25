using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class renameinseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GPs",
                keyColumn: "GPId",
                keyValue: 1,
                column: "UserName",
                value: "Læge-B-Ordrup");

            migrationBuilder.UpdateData(
                table: "GPs",
                keyColumn: "GPId",
                keyValue: 2,
                column: "UserName",
                value: "Læge-K-Spellenberg");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "UserName",
                value: "Patient-P-Hansen");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "UserName",
                value: "Patient-O-Jensen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "GPs",
                keyColumn: "GPId",
                keyValue: 1,
                column: "UserName",
                value: "Læge 1");

            migrationBuilder.UpdateData(
                table: "GPs",
                keyColumn: "GPId",
                keyValue: 2,
                column: "UserName",
                value: "Læge 2");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1,
                column: "UserName",
                value: "Patient A");

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 2,
                column: "UserName",
                value: "Patient B");
        }
    }
}
