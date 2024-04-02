using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCLNAO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Amoni",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amoni",
                table: "ThongSoCLNAo");
        }
    }
}
