using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFairAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditCandidatesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Candidates",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Candidates",
                newName: "UserName");
        }
    }
}
