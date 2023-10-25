using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class newtestdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentMessage",
                value: "Jævnligt meget ondt i hovedet");

            migrationBuilder.InsertData(
                table: "EConsultations",
                columns: new[] { "EConsultationId", "Answer", "AnswerTime", "Closed", "GPId", "PatientId", "Question", "QuestionTime" },
                values: new object[,]
                {
                    { 1, null, null, false, 1, 2, "Kan du se om der kommet svar fra Riget?", new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, null, false, 2, 1, "Jeg har meget ondt i min venstre skulder efter et uheld på job - kan jeg evt få recept eller skal du se mig først?", new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, null, false, 2, 2, "Min høfeber er helt enorm lige nu - måske skal jeg op i dosis?", new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Det er helt normalt - ikke så meget vi kan gøre her fra. Det skal løbes væk", new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 2, "Jeg har meget svært ved at komme op af sengen om mandagen - kan man gøre noget?", new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentMessage",
                value: "Hul i hovedet");
        }
    }
}
