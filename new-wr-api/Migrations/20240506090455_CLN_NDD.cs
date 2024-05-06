using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class CLN_NDD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TDSMin",
                table: "CLN_NDD",
                newName: "Y");

            migrationBuilder.RenameColumn(
                name: "TDSMax",
                table: "CLN_NDD",
                newName: "X");

            migrationBuilder.RenameColumn(
                name: "SongSuoiHoChua",
                table: "CLN_NDD",
                newName: "TangChuaNuoc");

            migrationBuilder.RenameColumn(
                name: "PhMin",
                table: "CLN_NDD",
                newName: "TDSDot3");

            migrationBuilder.RenameColumn(
                name: "PhMax",
                table: "CLN_NDD",
                newName: "TDSDot2");

            migrationBuilder.RenameColumn(
                name: "NitrateMin",
                table: "CLN_NDD",
                newName: "TDSDot1");

            migrationBuilder.RenameColumn(
                name: "NitrateMax",
                table: "CLN_NDD",
                newName: "PhDot3");

            migrationBuilder.RenameColumn(
                name: "GhiChu",
                table: "CLN_NDD",
                newName: "KyHieuDiemQuanTrac");

            migrationBuilder.RenameColumn(
                name: "DoCungMin",
                table: "CLN_NDD",
                newName: "PhDot2");

            migrationBuilder.RenameColumn(
                name: "DoCungMax",
                table: "CLN_NDD",
                newName: "PhDot1");

            migrationBuilder.RenameColumn(
                name: "ColiformMin",
                table: "CLN_NDD",
                newName: "NitrateDot3");

            migrationBuilder.RenameColumn(
                name: "ColiformMax",
                table: "CLN_NDD",
                newName: "NitrateDot2");

            migrationBuilder.RenameColumn(
                name: "ChlorideMin",
                table: "CLN_NDD",
                newName: "NitrateDot1");

            migrationBuilder.RenameColumn(
                name: "ChlorideMax",
                table: "CLN_NDD",
                newName: "DoCungDot3");

            migrationBuilder.RenameColumn(
                name: "AmoniMin",
                table: "CLN_NDD",
                newName: "DoCungDot2");

            migrationBuilder.RenameColumn(
                name: "AmoniMax",
                table: "CLN_NDD",
                newName: "DoCungDot1");

            migrationBuilder.RenameColumn(
                name: "ASMin",
                table: "CLN_NDD",
                newName: "ColiformDot3");

            migrationBuilder.RenameColumn(
                name: "ASMax",
                table: "CLN_NDD",
                newName: "ColiformDot2");

            migrationBuilder.AddColumn<double>(
                name: "AmoniDot1",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AmoniDot2",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AmoniDot3",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ArsenicDot1",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ArsenicDot2",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ArsenicDot3",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ChlorideDot1",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ChlorideDot2",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ChlorideDot3",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ColiformDot1",
                table: "CLN_NDD",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ThoiGianQuanTrac",
                table: "CLN_NDD",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmoniDot1",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "AmoniDot2",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "AmoniDot3",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "ArsenicDot1",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "ArsenicDot2",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "ArsenicDot3",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "ChlorideDot1",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "ChlorideDot2",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "ChlorideDot3",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "ColiformDot1",
                table: "CLN_NDD");

            migrationBuilder.DropColumn(
                name: "ThoiGianQuanTrac",
                table: "CLN_NDD");

            migrationBuilder.RenameColumn(
                name: "Y",
                table: "CLN_NDD",
                newName: "TDSMin");

            migrationBuilder.RenameColumn(
                name: "X",
                table: "CLN_NDD",
                newName: "TDSMax");

            migrationBuilder.RenameColumn(
                name: "TangChuaNuoc",
                table: "CLN_NDD",
                newName: "SongSuoiHoChua");

            migrationBuilder.RenameColumn(
                name: "TDSDot3",
                table: "CLN_NDD",
                newName: "PhMin");

            migrationBuilder.RenameColumn(
                name: "TDSDot2",
                table: "CLN_NDD",
                newName: "PhMax");

            migrationBuilder.RenameColumn(
                name: "TDSDot1",
                table: "CLN_NDD",
                newName: "NitrateMin");

            migrationBuilder.RenameColumn(
                name: "PhDot3",
                table: "CLN_NDD",
                newName: "NitrateMax");

            migrationBuilder.RenameColumn(
                name: "PhDot2",
                table: "CLN_NDD",
                newName: "DoCungMin");

            migrationBuilder.RenameColumn(
                name: "PhDot1",
                table: "CLN_NDD",
                newName: "DoCungMax");

            migrationBuilder.RenameColumn(
                name: "NitrateDot3",
                table: "CLN_NDD",
                newName: "ColiformMin");

            migrationBuilder.RenameColumn(
                name: "NitrateDot2",
                table: "CLN_NDD",
                newName: "ColiformMax");

            migrationBuilder.RenameColumn(
                name: "NitrateDot1",
                table: "CLN_NDD",
                newName: "ChlorideMin");

            migrationBuilder.RenameColumn(
                name: "KyHieuDiemQuanTrac",
                table: "CLN_NDD",
                newName: "GhiChu");

            migrationBuilder.RenameColumn(
                name: "DoCungDot3",
                table: "CLN_NDD",
                newName: "ChlorideMax");

            migrationBuilder.RenameColumn(
                name: "DoCungDot2",
                table: "CLN_NDD",
                newName: "AmoniMin");

            migrationBuilder.RenameColumn(
                name: "DoCungDot1",
                table: "CLN_NDD",
                newName: "AmoniMax");

            migrationBuilder.RenameColumn(
                name: "ColiformDot3",
                table: "CLN_NDD",
                newName: "ASMin");

            migrationBuilder.RenameColumn(
                name: "ColiformDot2",
                table: "CLN_NDD",
                newName: "ASMax");
        }
    }
}
