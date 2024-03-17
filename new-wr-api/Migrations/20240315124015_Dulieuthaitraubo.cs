using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class Dulieuthaitraubo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrauBo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    SoDan = table.Column<int>(type: "int", nullable: true),
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
                name: "IX_DuLieuNguonNuocThaiTrauBo_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrauBo",
                column: "IdPhanDoanSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrauBo");
        }
    }
}
