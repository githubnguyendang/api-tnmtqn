using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuNguonNuocThaiDiem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiDiem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    LuuLuongXaThai = table.Column<double>(type: "float", nullable: true),
                    NguonThaiCongTrinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToaDoX = table.Column<double>(type: "float", nullable: true),
                    ToaDoY = table.Column<double>(type: "float", nullable: true),
                    CtdiemBOD = table.Column<double>(type: "float", nullable: true),
                    CtdiemCOD = table.Column<double>(type: "float", nullable: true),
                    CtdiemAmoni = table.Column<double>(type: "float", nullable: true),
                    CtdiemTongN = table.Column<double>(type: "float", nullable: true),
                    CtdiemTongP = table.Column<double>(type: "float", nullable: true),
                    CtdiemTSS = table.Column<double>(type: "float", nullable: true),
                    CtdiemColiform = table.Column<double>(type: "float", nullable: true),
                    LtdiemBOD = table.Column<double>(type: "float", nullable: true),
                    LtdiemCOD = table.Column<double>(type: "float", nullable: true),
                    LtdiemAmoni = table.Column<double>(type: "float", nullable: true),
                    LtdiemTongN = table.Column<double>(type: "float", nullable: true),
                    LtdiemTongP = table.Column<double>(type: "float", nullable: true),
                    LtdiemTSS = table.Column<double>(type: "float", nullable: true),
                    LtdiemColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiDiem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiDiem_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiDiem_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiDiem",
                column: "IdPhanDoanSong",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiDiem");
        }
    }
}
