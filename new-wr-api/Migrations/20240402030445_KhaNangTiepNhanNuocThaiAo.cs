using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class KhaNangTiepNhanNuocThaiAo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pH",
                table: "ThongSoCLNAo",
                newName: "PH");

            migrationBuilder.AlterColumn<double>(
                name: "PH",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TongPhosphor",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TongNito",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TongColiform",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TSS",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "TOC",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "DO",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ColiformChiuNhiet",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Chiorophylla",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "COD",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "BOD",
                table: "ThongSoCLNAo",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ThongTinAoHo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdHoChua = table.Column<int>(type: "int", nullable: false),
                    IdCLNQC = table.Column<int>(type: "int", nullable: false),
                    CnnBOD = table.Column<double>(type: "float", nullable: true),
                    CnnCOD = table.Column<double>(type: "float", nullable: true),
                    CnnAmoni = table.Column<double>(type: "float", nullable: true),
                    CnnTongN = table.Column<double>(type: "float", nullable: true),
                    CnnTongP = table.Column<double>(type: "float", nullable: true),
                    CnnTSS = table.Column<double>(type: "float", nullable: true),
                    CnnColiform = table.Column<double>(type: "float", nullable: true),
                    MtnBOD = table.Column<double>(type: "float", nullable: true),
                    MtnCOD = table.Column<double>(type: "float", nullable: true),
                    MtnAmoni = table.Column<double>(type: "float", nullable: true),
                    MtnTongN = table.Column<double>(type: "float", nullable: true),
                    MtnTongP = table.Column<double>(type: "float", nullable: true),
                    MtnTSS = table.Column<double>(type: "float", nullable: true),
                    MtnColiform = table.Column<double>(type: "float", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaiKhoanTao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThoiGianSua = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaiKhoanSua = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaXoa = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinAoHo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongTinAoHo_CT_ThongTin_IdHoChua",
                        column: x => x.IdHoChua,
                        principalTable: "CT_ThongTin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongTinAoHo_ThongSoCLNAo_IdCLNQC",
                        column: x => x.IdCLNQC,
                        principalTable: "ThongSoCLNAo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinAoHo_IdCLNQC",
                table: "ThongTinAoHo",
                column: "IdCLNQC");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinAoHo_IdHoChua",
                table: "ThongTinAoHo",
                column: "IdHoChua");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongTinAoHo");

            migrationBuilder.RenameColumn(
                name: "PH",
                table: "ThongSoCLNAo",
                newName: "pH");

            migrationBuilder.AlterColumn<string>(
                name: "TongPhosphor",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TongNito",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TongColiform",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TSS",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TOC",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pH",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DO",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ColiformChiuNhiet",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Chiorophylla",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "COD",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BOD",
                table: "ThongSoCLNAo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
