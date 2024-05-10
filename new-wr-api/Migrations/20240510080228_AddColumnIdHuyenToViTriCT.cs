using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnIdHuyenToViTriCT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdHuyen",
                table: "CT_ViTri",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CT_ViTri_IdHuyen",
                table: "CT_ViTri",
                column: "IdHuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ViTri_Huyen_IdHuyen",
                table: "CT_ViTri",
                column: "IdHuyen",
                principalTable: "Huyen",
                principalColumn: "IdHuyen");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CT_ViTri_Huyen_IdHuyen",
                table: "CT_ViTri");

            migrationBuilder.DropIndex(
                name: "IX_CT_ViTri_IdHuyen",
                table: "CT_ViTri");

            migrationBuilder.DropColumn(
                name: "IdHuyen",
                table: "CT_ViTri");
        }
    }
}
