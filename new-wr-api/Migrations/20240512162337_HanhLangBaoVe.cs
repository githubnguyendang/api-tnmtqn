using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class HanhLangBaoVe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiaPhanHanhChinh",
                table: "NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiHo",
                table: "NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaPhanHanhChinh",
                table: "NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiHo",
                table: "NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiaPhanHanhChinh",
                table: "NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTao",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiaPhanHanhChinh",
                table: "NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3");

            migrationBuilder.DropColumn(
                name: "LoaiHo",
                table: "NN_HanhLangBaoVeNN_HoThuyLoiNhieuHon1m3");

            migrationBuilder.DropColumn(
                name: "DiaPhanHanhChinh",
                table: "NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3");

            migrationBuilder.DropColumn(
                name: "LoaiHo",
                table: "NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3");

            migrationBuilder.DropColumn(
                name: "DiaPhanHanhChinh",
                table: "NN_HanhLangBaoVeNN_AoHoDamTuNhienNhanTao");
        }
    }
}
