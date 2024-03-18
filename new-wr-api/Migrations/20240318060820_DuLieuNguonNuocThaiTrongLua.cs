using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class DuLieuNguonNuocThaiTrongLua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DuLieuNguonNuocThaiTrongLua",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPhanDoanSong = table.Column<int>(type: "int", nullable: false),
                    DienTichTrongLua = table.Column<double>(type: "float", nullable: true),
                    HeSoSuyGiam = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaBOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaCOD = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaAmoni = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaTongN = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaTongP = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaTSS = table.Column<double>(type: "float", nullable: true),
                    CtTrongLuaColiform = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaBOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaCOD = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaAmoni = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaTongN = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaTongP = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaTSS = table.Column<double>(type: "float", nullable: true),
                    LtTrongLuaColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuNguonNuocThaiTrongLua", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuNguonNuocThaiTrongLua_PhanDoanSong_IdPhanDoanSong",
                        column: x => x.IdPhanDoanSong,
                        principalTable: "PhanDoanSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuNguonNuocThaiTrongLua_IdPhanDoanSong",
                table: "DuLieuNguonNuocThaiTrongLua",
                column: "IdPhanDoanSong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuNguonNuocThaiTrongLua");
        }
    }
}
