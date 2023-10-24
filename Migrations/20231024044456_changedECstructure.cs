using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class changedECstructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ECMessages");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "EConsultations",
                newName: "Question");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "EConsultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnswerTime",
                table: "EConsultations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "QuestionTime",
                table: "EConsultations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "EConsultations");

            migrationBuilder.DropColumn(
                name: "AnswerTime",
                table: "EConsultations");

            migrationBuilder.DropColumn(
                name: "QuestionTime",
                table: "EConsultations");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "EConsultations",
                newName: "Subject");

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

            migrationBuilder.CreateIndex(
                name: "IX_ECMessages_EConsultationId",
                table: "ECMessages",
                column: "EConsultationId");
        }
    }
}
