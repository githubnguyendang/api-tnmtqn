using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace new_wr_api.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationshipLuuVuc_CongTrinh : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CT_ThongTin_IdLuuVuc",
                table: "CT_ThongTin",
                column: "IdLuuVuc");

            migrationBuilder.AddForeignKey(
                name: "FK_CT_ThongTin_LuuVucSong_IdLuuVuc",
                table: "CT_ThongTin",
                column: "IdLuuVuc",
                principalTable: "LuuVucSong",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CT_ThongTin_LuuVucSong_IdLuuVuc",
                table: "CT_ThongTin");

            migrationBuilder.DropIndex(
                name: "IX_CT_ThongTin_IdLuuVuc",
                table: "CT_ThongTin");
        }
    }
}
