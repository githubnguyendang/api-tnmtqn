using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class Sua_IdTram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuLieuTram_Tram_ThongTin_IdLoaiTram",
                table: "DuLieuTram");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuTram_IdLoaiTram",
                table: "DuLieuTram");

            migrationBuilder.DropColumn(
                name: "IdLoaiTram",
                table: "DuLieuTram");

            migrationBuilder.AddColumn<int>(
                name: "IdTram",
                table: "DuLieuTram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTram_IdTram",
                table: "DuLieuTram",
                column: "IdTram");

            migrationBuilder.AddForeignKey(
                name: "FK_DuLieuTram_Tram_ThongTin_IdTram",
                table: "DuLieuTram",
                column: "IdTram",
                principalTable: "Tram_ThongTin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuLieuTram_Tram_ThongTin_IdTram",
                table: "DuLieuTram");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuTram_IdTram",
                table: "DuLieuTram");

            migrationBuilder.DropColumn(
                name: "IdTram",
                table: "DuLieuTram");

            migrationBuilder.AddColumn<int>(
                name: "IdLoaiTram",
                table: "DuLieuTram",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTram_IdLoaiTram",
                table: "DuLieuTram",
                column: "IdLoaiTram");

            migrationBuilder.AddForeignKey(
                name: "FK_DuLieuTram_Tram_ThongTin_IdLoaiTram",
                table: "DuLieuTram",
                column: "IdLoaiTram",
                principalTable: "Tram_ThongTin",
                principalColumn: "Id");
        }
    }
}
