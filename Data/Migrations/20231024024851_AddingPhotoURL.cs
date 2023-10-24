using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobFairAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingPhotoURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Candidates",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Candidates");
        }
    }
}
