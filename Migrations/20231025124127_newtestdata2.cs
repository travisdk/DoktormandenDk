using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class newtestdata2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 1,
                column: "QuestionTime",
                value: new DateTime(2023, 7, 7, 15, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 2,
                column: "QuestionTime",
                value: new DateTime(2023, 7, 6, 11, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 3,
                column: "QuestionTime",
                value: new DateTime(2023, 9, 21, 12, 30, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 4,
                column: "AnswerTime",
                value: new DateTime(2023, 10, 11, 13, 30, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 1,
                column: "QuestionTime",
                value: new DateTime(2023, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 2,
                column: "QuestionTime",
                value: new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 3,
                column: "QuestionTime",
                value: new DateTime(2023, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EConsultations",
                keyColumn: "EConsultationId",
                keyValue: 4,
                column: "AnswerTime",
                value: new DateTime(2023, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
