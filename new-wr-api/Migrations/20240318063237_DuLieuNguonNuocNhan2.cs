using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuNguonNuocNhan2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChieuDai",
                table: "DuLieuNguonNuocNhan");

            migrationBuilder.DropColumn(
                name: "Song",
                table: "DuLieuNguonNuocNhan");

            migrationBuilder.DropColumn(
                name: "TenDoanSong",
                table: "DuLieuNguonNuocNhan");

            migrationBuilder.AddColumn<int>(
                name: "IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocNhan_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan",
                column: "IdPhanDoanSong");

            migrationBuilder.AddForeignKey(
                name: "FK_DuLieuNguonNuocNhan_PhanDoanSong_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan",
                column: "IdPhanDoanSong",
                principalTable: "PhanDoanSong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuLieuNguonNuocNhan_PhanDoanSong_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan");

            migrationBuilder.DropIndex(
                name: "IX_DuLieuNguonNuocNhan_IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan");

            migrationBuilder.DropColumn(
                name: "IdPhanDoanSong",
                table: "DuLieuNguonNuocNhan");

            migrationBuilder.AddColumn<double>(
                name: "ChieuDai",
                table: "DuLieuNguonNuocNhan",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Song",
                table: "DuLieuNguonNuocNhan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenDoanSong",
                table: "DuLieuNguonNuocNhan",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
