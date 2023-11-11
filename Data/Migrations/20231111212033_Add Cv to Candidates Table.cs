using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFairAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCvtoCandidatesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cv",
                table: "Candidates",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cv",
                table: "Candidates");
        }
    }
}
