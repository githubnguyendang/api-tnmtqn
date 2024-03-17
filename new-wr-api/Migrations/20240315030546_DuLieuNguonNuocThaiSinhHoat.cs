using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuNguonNuocThaiSinhHoat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NguonThaiCongTrinh",
                table: "DuLieuNguonNuocThaiDiem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ToaDoX",
                table: "DuLieuNguonNuocThaiDiem",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ToaDoY",
                table: "DuLieuNguonNuocThaiDiem",
                type: "float",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiSinhHoat_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiSinhHoat",
                column: "IdPhanDoanSong",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiSinhHoat");

            migrationBuilder.DropColumn(
                name: "NguonThaiCongTrinh",
                table: "DuLieuNguonNuocThaiDiem");

            migrationBuilder.DropColumn(
                name: "ToaDoX",
                table: "DuLieuNguonNuocThaiDiem");

            migrationBuilder.DropColumn(
                name: "ToaDoY",
                table: "DuLieuNguonNuocThaiDiem");
        }
    }
}
