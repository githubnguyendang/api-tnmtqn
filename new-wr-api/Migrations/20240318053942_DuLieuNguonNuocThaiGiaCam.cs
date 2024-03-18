using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuNguonNuocThaiGiaCam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiGiaCam",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoGiaCam = table.Column<int>(type: "int", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamBOD = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamCOD = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamAmoni = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamTongN = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamTongP = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamTSS = table.Column<double>(type: "float", nullable: true),
                    CtGiaCamColiform = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamBOD = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamCOD = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamAmoni = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamTongN = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamTongP = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamTSS = table.Column<double>(type: "float", nullable: true),
                    LtGiaCamColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiGiaCam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiGiaCam_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiGiaCam_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiGiaCam",
                column: "IdPhanDoanSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiGiaCam");
        }
    }
}
