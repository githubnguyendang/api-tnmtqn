using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class TaiLuongThai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRung_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRung");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLua_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLua");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCay_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCay");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBo_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBo");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiLon_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLon");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCam_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCam");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocNhan_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRung_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRung",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLua_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLua",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCay_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCay",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBo_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBo",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiLon_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLon",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCam_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCam",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocNhan_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan",
                column: "IdPhanDoanSong",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRung_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRung");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLua_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLua");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCay_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCay");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBo_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBo");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiLon_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLon");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCam_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCam");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocNhan_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRung_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRung",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLua_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLua",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCay_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCay",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBo_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBo",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiLon_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLon",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCam_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCam",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocNhan_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan",
                column: "IdPhanDoanSong");
        }
    }
}
