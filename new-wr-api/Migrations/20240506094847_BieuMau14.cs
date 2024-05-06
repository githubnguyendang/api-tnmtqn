using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class BieuMau14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AmoniLonNhat",
                table: "BieuMauSoMuoiBon",
                newName: "AmonilonNhat");

            migrationBuilder.RenameColumn(
                name: "SulfatNhoNhat",
                table: "BieuMauSoMuoiBon",
                newName: "TDSlonNhat");

            migrationBuilder.RenameColumn(
                name: "SulfatLonNhat",
                table: "BieuMauSoMuoiBon",
                newName: "TDSNhoNhat");

            migrationBuilder.RenameColumn(
                name: "NitratNhoNhat",
                table: "BieuMauSoMuoiBon",
                newName: "NitratelonNhat");

            migrationBuilder.RenameColumn(
                name: "NitratLonNhat",
                table: "BieuMauSoMuoiBon",
                newName: "NitrateNhoNhat");

            migrationBuilder.RenameColumn(
                name: "AsenNhoNhat",
                table: "BieuMauSoMuoiBon",
                newName: "ColiformlonNhat");

            migrationBuilder.RenameColumn(
                name: "AsenLonNhat",
                table: "BieuMauSoMuoiBon",
                newName: "ColiformNhoNhat");

            migrationBuilder.AddColumn<double>(
                name: "ArsenicLonNhat",
                table: "BieuMauSoMuoiBon",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ArsenicNhoNhat",
                table: "BieuMauSoMuoiBon",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ChlorideLonNhat",
                table: "BieuMauSoMuoiBon",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ChlorideNhoNhat",
                table: "BieuMauSoMuoiBon",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LuuVucSong",
                table: "BieuMauSoMuoiBon",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TangChuaNuoc",
                table: "BieuMauSoMuoiBon",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArsenicLonNhat",
                table: "BieuMauSoMuoiBon");

            migrationBuilder.DropColumn(
                name: "ArsenicNhoNhat",
                table: "BieuMauSoMuoiBon");

            migrationBuilder.DropColumn(
                name: "ChlorideLonNhat",
                table: "BieuMauSoMuoiBon");

            migrationBuilder.DropColumn(
                name: "ChlorideNhoNhat",
                table: "BieuMauSoMuoiBon");

            migrationBuilder.DropColumn(
                name: "LuuVucSong",
                table: "BieuMauSoMuoiBon");

            migrationBuilder.DropColumn(
                name: "TangChuaNuoc",
                table: "BieuMauSoMuoiBon");

            migrationBuilder.RenameColumn(
                name: "AmonilonNhat",
                table: "BieuMauSoMuoiBon",
                newName: "AmoniLonNhat");

            migrationBuilder.RenameColumn(
                name: "TDSlonNhat",
                table: "BieuMauSoMuoiBon",
                newName: "SulfatNhoNhat");

            migrationBuilder.RenameColumn(
                name: "TDSNhoNhat",
                table: "BieuMauSoMuoiBon",
                newName: "SulfatLonNhat");

            migrationBuilder.RenameColumn(
                name: "NitratelonNhat",
                table: "BieuMauSoMuoiBon",
                newName: "NitratNhoNhat");

            migrationBuilder.RenameColumn(
                name: "NitrateNhoNhat",
                table: "BieuMauSoMuoiBon",
                newName: "NitratLonNhat");

            migrationBuilder.RenameColumn(
                name: "ColiformlonNhat",
                table: "BieuMauSoMuoiBon",
                newName: "AsenNhoNhat");

            migrationBuilder.RenameColumn(
                name: "ColiformNhoNhat",
                table: "BieuMauSoMuoiBon",
                newName: "AsenLonNhat");
        }
    }
}
