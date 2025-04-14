using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamDaoTao.Migrations
{
    /// <inheritdoc />
    public partial class dariussssdsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKyKhoaHocs_HocViens_MaHocVien",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyKhoaHocs_KhoaHocs_MaKhoaHoc",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DangKyKhoaHocs",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HocViens",
                table: "HocViens");

            migrationBuilder.DropColumn(
                name: "isQuantrivien",
                table: "HocViens");

            migrationBuilder.RenameTable(
                name: "HocViens",
                newName: "Users");

            migrationBuilder.AddColumn<int>(
                name: "MaDangKy",
                table: "DangKyKhoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DangKyKhoaHocs",
                table: "DangKyKhoaHocs",
                column: "MaDangKy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "MaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyKhoaHocs_MaHocVien",
                table: "DangKyKhoaHocs",
                column: "MaHocVien");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyKhoaHocs_KhoaHocs_MaKhoaHoc",
                table: "DangKyKhoaHocs",
                column: "MaKhoaHoc",
                principalTable: "KhoaHocs",
                principalColumn: "MaKhoaHoc",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyKhoaHocs_Users_MaHocVien",
                table: "DangKyKhoaHocs",
                column: "MaHocVien",
                principalTable: "Users",
                principalColumn: "MaHocVien",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKyKhoaHocs_KhoaHocs_MaKhoaHoc",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyKhoaHocs_Users_MaHocVien",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DangKyKhoaHocs",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropIndex(
                name: "IX_DangKyKhoaHocs_MaHocVien",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MaDangKy",
                table: "DangKyKhoaHocs");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "HocViens");

            migrationBuilder.AddColumn<bool>(
                name: "isQuantrivien",
                table: "HocViens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DangKyKhoaHocs",
                table: "DangKyKhoaHocs",
                columns: new[] { "MaHocVien", "MaKhoaHoc" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_HocViens",
                table: "HocViens",
                column: "MaHocVien");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyKhoaHocs_HocViens_MaHocVien",
                table: "DangKyKhoaHocs",
                column: "MaHocVien",
                principalTable: "HocViens",
                principalColumn: "MaHocVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyKhoaHocs_KhoaHocs_MaKhoaHoc",
                table: "DangKyKhoaHocs",
                column: "MaKhoaHoc",
                principalTable: "KhoaHocs",
                principalColumn: "MaKhoaHoc",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
