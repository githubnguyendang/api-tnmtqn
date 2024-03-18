using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuNguonNuocThaiLon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiLon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoLon = table.Column<int>(type: "int", nullable: true),
                    SoDe = table.Column<int>(type: "int", nullable: true),
                    SoGiaSucKhac = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtLonBOD = table.Column<double>(type: "float", nullable: true),
                    CtLonCOD = table.Column<double>(type: "float", nullable: true),
                    CtLonAmoni = table.Column<double>(type: "float", nullable: true),
                    CtLonTongN = table.Column<double>(type: "float", nullable: true),
                    CtLonTongP = table.Column<double>(type: "float", nullable: true),
                    CtLonTSS = table.Column<double>(type: "float", nullable: true),
                    CtLonColiform = table.Column<double>(type: "float", nullable: true),
                    LtLonBOD = table.Column<double>(type: "float", nullable: true),
                    LtLonCOD = table.Column<double>(type: "float", nullable: true),
                    LtLonAmoni = table.Column<double>(type: "float", nullable: true),
                    LtLonTongN = table.Column<double>(type: "float", nullable: true),
                    LtLonTongP = table.Column<double>(type: "float", nullable: true),
                    LtLonTSS = table.Column<double>(type: "float", nullable: true),
                    LtLonColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiLon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiLon_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiSinhHoat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoDan = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatBOD = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatCOD = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatAmoni = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatTongN = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatTongP = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatTSS = table.Column<double>(type: "float", nullable: true),
                    CtSinhHoatColiform = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatBOD = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatCOD = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatAmoni = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatTongN = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatTongP = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatTSS = table.Column<double>(type: "float", nullable: true),
                    LtSinhHoatColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiSinhHoat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiSinhHoat_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrauBo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoTrau = table.Column<int>(type: "int", nullable: true),
                    SoBo = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoBOD = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoCOD = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoAmoni = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoTongN = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoTongP = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoTSS = table.Column<double>(type: "float", nullable: true),
                    CtTrauBoColiform = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoBOD = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoCOD = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoAmoni = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoTongN = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoTongP = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoTSS = table.Column<double>(type: "float", nullable: true),
                    LtTrauBoColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrauBo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrauBo_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiLon_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiLon",
                column: "IdPhanDoanSong");

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiSinhHoat_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiSinhHoat",
                column: "IdPhanDoanSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrauBo_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBo",
                column: "IdPhanDoanSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiLon");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiSinhHoat");

            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrauBo");
        }
    }
}
