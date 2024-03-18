using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuNguonNuocThaiTrongRung : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrongRung",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichTrongRung = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungBOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungCOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungAmoni = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungTongN = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungTongP = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungTSS = table.Column<double>(type: "float", nullable: true),
                    CtTrongRungColiform = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungBOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungCOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungAmoni = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungTongN = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungTongP = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungTSS = table.Column<double>(type: "float", nullable: true),
                    LtTrongRungColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrongRung", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrongRung_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongRung_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongRung",
                column: "IdPhanDoanSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrongRung");
        }
    }
}
