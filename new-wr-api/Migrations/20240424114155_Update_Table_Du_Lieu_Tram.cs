using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class Update_Table_Du_Lieu_Tram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TramQuangNgai");

            migrationBuilder.CreateTable(
                name: "DuLieuTram",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTram = table.Column<int>(type: "int", nullable: true),
                    TenTram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LuongMua = table.Column<double>(type: "float", nullable: true),
                    NhietDo = table.Column<double>(type: "float", nullable: true),
                    DoAm = table.Column<double>(type: "float", nullable: true),
                    HuongGio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TocDoGio = table.Column<double>(type: "float", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuLieuTram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuLieuTram_Tram_ThongTin_IdTram",
                        column: x => x.IdTram,
                        principalTable: "Tram_ThongTin",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuLieuTram_IdTram",
                table: "DuLieuTram",
                column: "IdTram");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuLieuTram");

            migrationBuilder.CreateTable(
                name: "TramQuangNgai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true),
                    DoAm = table.Column<double>(type: "float", nullable: true),
                    LuongMua = table.Column<double>(type: "float", nullable: true),
                    NhietDo = table.Column<double>(type: "float", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGian = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ThoiGianTao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TocDoGio = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TramQuangNgai", x => x.Id);
                });
        }
    }
}
