using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class SoTrauBo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoDan",
                table: "DuLieuNguonNuocThaiTrauBo",
                newName: "SoTrau");

            migrationBuilder.AddColumn<int>(
                name: "SoBo",
                table: "DuLieuNguonNuocThaiTrauBo",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoBo",
                table: "DuLieuNguonNuocThaiTrauBo");

            migrationBuilder.RenameColumn(
                name: "SoTrau",
                table: "DuLieuNguonNuocThaiTrauBo",
                newName: "SoDan");
        }
    }
}
