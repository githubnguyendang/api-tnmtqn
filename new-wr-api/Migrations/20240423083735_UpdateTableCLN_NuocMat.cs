using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableCLN_NuocMat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "CLN_NuocMat");

            migrationBuilder.RenameColumn(
                name: "TSSMin",
                table: "CLN_NuocMat",
                newName: "photpho_dot3");

            migrationBuilder.RenameColumn(
                name: "TSSMax",
                table: "CLN_NuocMat",
                newName: "photpho_dot2");

            migrationBuilder.RenameColumn(
                name: "PhosphorTPMin",
                table: "CLN_NuocMat",
                newName: "photpho_dot1");

            migrationBuilder.RenameColumn(
                name: "PhosphorTPMax",
                table: "CLN_NuocMat",
                newName: "ph_dot3");

            migrationBuilder.RenameColumn(
                name: "PhMin",
                table: "CLN_NuocMat",
                newName: "ph_dot2");

            migrationBuilder.RenameColumn(
                name: "PhMax",
                table: "CLN_NuocMat",
                newName: "ph_dot1");

            migrationBuilder.RenameColumn(
                name: "NitoTNMin",
                table: "CLN_NuocMat",
                newName: "nito_dot3");

            migrationBuilder.RenameColumn(
                name: "NitoTNMax",
                table: "CLN_NuocMat",
                newName: "nito_dot2");

            migrationBuilder.RenameColumn(
                name: "DOMin",
                table: "CLN_NuocMat",
                newName: "nito_dot1");

            migrationBuilder.RenameColumn(
                name: "DOMax",
                table: "CLN_NuocMat",
                newName: "do_dot3");

            migrationBuilder.RenameColumn(
                name: "CODMin",
                table: "CLN_NuocMat",
                newName: "do_dot2");

            migrationBuilder.RenameColumn(
                name: "CODMax",
                table: "CLN_NuocMat",
                newName: "do_dot1");

            migrationBuilder.RenameColumn(
                name: "BOD5Min",
                table: "CLN_NuocMat",
                newName: "cod_dot3");

            migrationBuilder.RenameColumn(
                name: "BOD5Max",
                table: "CLN_NuocMat",
                newName: "cod_dot2");

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianQuanTrac",
                table: "CLN_NuocMat",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "bod5_dot1",
                table: "CLN_NuocMat",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "bod5_dot2",
                table: "CLN_NuocMat",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "bod5_dot3",
                table: "CLN_NuocMat",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "cod_dot1",
                table: "CLN_NuocMat",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bod5_dot1",
                table: "CLN_NuocMat");

            migrationBuilder.DropColumn(
                name: "bod5_dot2",
                table: "CLN_NuocMat");

            migrationBuilder.DropColumn(
                name: "bod5_dot3",
                table: "CLN_NuocMat");

            migrationBuilder.DropColumn(
                name: "cod_dot1",
                table: "CLN_NuocMat");

            migrationBuilder.RenameColumn(
                name: "photpho_dot3",
                table: "CLN_NuocMat",
                newName: "TSSMin");

            migrationBuilder.RenameColumn(
                name: "photpho_dot2",
                table: "CLN_NuocMat",
                newName: "TSSMax");

            migrationBuilder.RenameColumn(
                name: "photpho_dot1",
                table: "CLN_NuocMat",
                newName: "PhosphorTPMin");

            migrationBuilder.RenameColumn(
                name: "ph_dot3",
                table: "CLN_NuocMat",
                newName: "PhosphorTPMax");

            migrationBuilder.RenameColumn(
                name: "ph_dot2",
                table: "CLN_NuocMat",
                newName: "PhMin");

            migrationBuilder.RenameColumn(
                name: "ph_dot1",
                table: "CLN_NuocMat",
                newName: "PhMax");

            migrationBuilder.RenameColumn(
                name: "nito_dot3",
                table: "CLN_NuocMat",
                newName: "NitoTNMin");

            migrationBuilder.RenameColumn(
                name: "nito_dot2",
                table: "CLN_NuocMat",
                newName: "NitoTNMax");

            migrationBuilder.RenameColumn(
                name: "nito_dot1",
                table: "CLN_NuocMat",
                newName: "DOMin");

            migrationBuilder.RenameColumn(
                name: "do_dot3",
                table: "CLN_NuocMat",
                newName: "DOMax");

            migrationBuilder.RenameColumn(
                name: "do_dot2",
                table: "CLN_NuocMat",
                newName: "CODMin");

            migrationBuilder.RenameColumn(
                name: "do_dot1",
                table: "CLN_NuocMat",
                newName: "CODMax");

            migrationBuilder.RenameColumn(
                name: "cod_dot3",
                table: "CLN_NuocMat",
                newName: "BOD5Min");

            migrationBuilder.RenameColumn(
                name: "cod_dot2",
                table: "CLN_NuocMat",
                newName: "BOD5Max");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ThoiGianQuanTrac",
                table: "CLN_NuocMat",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "CLN_NuocMat",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
