using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableCLN_NuocMat1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "photpho_dot3",
                table: "CLN_NuocMat",
                newName: "PhotphoDot3");

            migrationBuilder.RenameColumn(
                name: "photpho_dot2",
                table: "CLN_NuocMat",
                newName: "PhotphoDot2");

            migrationBuilder.RenameColumn(
                name: "photpho_dot1",
                table: "CLN_NuocMat",
                newName: "PhotphoDot1");

            migrationBuilder.RenameColumn(
                name: "ph_dot3",
                table: "CLN_NuocMat",
                newName: "PhDot3");

            migrationBuilder.RenameColumn(
                name: "ph_dot2",
                table: "CLN_NuocMat",
                newName: "PhDot2");

            migrationBuilder.RenameColumn(
                name: "ph_dot1",
                table: "CLN_NuocMat",
                newName: "PhDot1");

            migrationBuilder.RenameColumn(
                name: "nito_dot3",
                table: "CLN_NuocMat",
                newName: "NitoDot3");

            migrationBuilder.RenameColumn(
                name: "nito_dot2",
                table: "CLN_NuocMat",
                newName: "NitoDot2");

            migrationBuilder.RenameColumn(
                name: "nito_dot1",
                table: "CLN_NuocMat",
                newName: "NitoDot1");

            migrationBuilder.RenameColumn(
                name: "do_dot3",
                table: "CLN_NuocMat",
                newName: "DODot3");

            migrationBuilder.RenameColumn(
                name: "do_dot2",
                table: "CLN_NuocMat",
                newName: "DODot2");

            migrationBuilder.RenameColumn(
                name: "do_dot1",
                table: "CLN_NuocMat",
                newName: "DODot1");

            migrationBuilder.RenameColumn(
                name: "cod_dot3",
                table: "CLN_NuocMat",
                newName: "CODDot3");

            migrationBuilder.RenameColumn(
                name: "cod_dot2",
                table: "CLN_NuocMat",
                newName: "CODDot2");

            migrationBuilder.RenameColumn(
                name: "cod_dot1",
                table: "CLN_NuocMat",
                newName: "CODDot1");

            migrationBuilder.RenameColumn(
                name: "bod5_dot3",
                table: "CLN_NuocMat",
                newName: "BOD5Dot3");

            migrationBuilder.RenameColumn(
                name: "bod5_dot2",
                table: "CLN_NuocMat",
                newName: "BOD5Dot2");

            migrationBuilder.RenameColumn(
                name: "bod5_dot1",
                table: "CLN_NuocMat",
                newName: "BOD5Dot1");

            migrationBuilder.AddColumn<string>(
                name: "KyHieuDiemQuanTrac",
                table: "CLN_NuocMat",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KyHieuDiemQuanTrac",
                table: "CLN_NuocMat");

            migrationBuilder.RenameColumn(
                name: "PhotphoDot3",
                table: "CLN_NuocMat",
                newName: "photpho_dot3");

            migrationBuilder.RenameColumn(
                name: "PhotphoDot2",
                table: "CLN_NuocMat",
                newName: "photpho_dot2");

            migrationBuilder.RenameColumn(
                name: "PhotphoDot1",
                table: "CLN_NuocMat",
                newName: "photpho_dot1");

            migrationBuilder.RenameColumn(
                name: "PhDot3",
                table: "CLN_NuocMat",
                newName: "ph_dot3");

            migrationBuilder.RenameColumn(
                name: "PhDot2",
                table: "CLN_NuocMat",
                newName: "ph_dot2");

            migrationBuilder.RenameColumn(
                name: "PhDot1",
                table: "CLN_NuocMat",
                newName: "ph_dot1");

            migrationBuilder.RenameColumn(
                name: "NitoDot3",
                table: "CLN_NuocMat",
                newName: "nito_dot3");

            migrationBuilder.RenameColumn(
                name: "NitoDot2",
                table: "CLN_NuocMat",
                newName: "nito_dot2");

            migrationBuilder.RenameColumn(
                name: "NitoDot1",
                table: "CLN_NuocMat",
                newName: "nito_dot1");

            migrationBuilder.RenameColumn(
                name: "DODot3",
                table: "CLN_NuocMat",
                newName: "do_dot3");

            migrationBuilder.RenameColumn(
                name: "DODot2",
                table: "CLN_NuocMat",
                newName: "do_dot2");

            migrationBuilder.RenameColumn(
                name: "DODot1",
                table: "CLN_NuocMat",
                newName: "do_dot1");

            migrationBuilder.RenameColumn(
                name: "CODDot3",
                table: "CLN_NuocMat",
                newName: "cod_dot3");

            migrationBuilder.RenameColumn(
                name: "CODDot2",
                table: "CLN_NuocMat",
                newName: "cod_dot2");

            migrationBuilder.RenameColumn(
                name: "CODDot1",
                table: "CLN_NuocMat",
                newName: "cod_dot1");

            migrationBuilder.RenameColumn(
                name: "BOD5Dot3",
                table: "CLN_NuocMat",
                newName: "bod5_dot3");

            migrationBuilder.RenameColumn(
                name: "BOD5Dot2",
                table: "CLN_NuocMat",
                newName: "bod5_dot2");

            migrationBuilder.RenameColumn(
                name: "BOD5Dot1",
                table: "CLN_NuocMat",
                newName: "bod5_dot1");
        }
    }
}
