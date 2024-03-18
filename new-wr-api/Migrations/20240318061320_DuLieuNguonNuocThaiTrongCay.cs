using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuNguonNuocThaiTrongCay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrongCay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichTrongCay = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayBOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayCOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayAmoni = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayTongN = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayTongP = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayTSS = table.Column<double>(type: "float", nullable: true),
                    CtTrongCayColiform = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayBOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayCOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayAmoni = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayTongN = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayTongP = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayTSS = table.Column<double>(type: "float", nullable: true),
                    LtTrongCayColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrongCay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrongCay_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongCay_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongCay",
                column: "IdPhanDoanSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrongCay");
        }
    }
}
