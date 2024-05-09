using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class Init_Databasea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CT_ThongTin_Huyen_HuyenIdHuyen",
                table: "CT_ThongTin");

            migrationBuilder.DropIndex(
                name: "IX_CT_ThongTin_HuyenIdHuyen",
                table: "CT_ThongTin");

            migrationBuilder.DropColumn(
                name: "HuyenIdHuyen",
                table: "CT_ThongTin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HuyenIdHuyen",
                table: "CT_ThongTin",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CT_ThongTin_HuyenIdHuyen",
                table: "CT_ThongTin",
                column: "HuyenIdHuyen");

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ThongTin_Huyen_HuyenIdHuyen",
                table: "CT_ThongTin",
                column: "HuyenIdHuyen",
                principalTable: "Huyen",
                principalColumn: "IdHuyen");
        }
    }
}
