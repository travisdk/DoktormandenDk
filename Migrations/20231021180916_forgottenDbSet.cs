using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class forgottenDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EConsultations",
                columns: table => new
                {
                    EConsultationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    GPId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EConsultations", x => x.EConsultationId);
                    table.ForeignKey(
                        name: "FK_EConsultations_GPs_GPId",
                        column: x => x.GPId,
                        principalTable: "GPs",
                        principalColumn: "GPId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EConsultations_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ECMessages",
                columns: table => new
                {
                    EcMessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EConsultationId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECMessages", x => x.EcMessageId);
                    table.ForeignKey(
                        name: "FK_ECMessages_EConsultations_EConsultationId",
                        column: x => x.EConsultationId,
                        principalTable: "EConsultations",
                        principalColumn: "EConsultationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 10, 21, 20, 9, 16, 387, DateTimeKind.Local).AddTicks(5084));

            migrationBuilder.CreateIndex(
                name: "IX_ECMessages_EConsultationId",
                table: "ECMessages",
                column: "EConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_EConsultations_GPId",
                table: "EConsultations",
                column: "GPId");

            migrationBuilder.CreateIndex(
                name: "IX_EConsultations_PatientId",
                table: "EConsultations",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ECMessages");

            migrationBuilder.DropTable(
                name: "EConsultations");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "AppointmentTime",
                value: new DateTime(2023, 10, 21, 19, 59, 23, 851, DateTimeKind.Local).AddTicks(7773));
        }
    }
}
