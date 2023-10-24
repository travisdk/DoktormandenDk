using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoktormandenDk.Migrations
{
    /// <inheritdoc />
    public partial class fieldClosedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "EConsultations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Closed",
                table: "EConsultations");
        }
    }
}
