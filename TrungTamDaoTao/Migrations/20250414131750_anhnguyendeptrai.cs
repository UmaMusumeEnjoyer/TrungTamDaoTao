using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamDaoTao.Migrations
{
    /// <inheritdoc />
    public partial class anhnguyendeptrai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKyKhoaHocs_HocViens_HocVienMaHocVien",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyKhoaHocs_KhoaHocs_KhoaHocMaKhoaHoc",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropIndex(
                name: "IX_DangKyKhoaHocs_HocVienMaHocVien",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropIndex(
                name: "IX_DangKyKhoaHocs_KhoaHocMaKhoaHoc",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropColumn(
                name: "HocVienMaHocVien",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropColumn(
                name: "KhoaHocMaKhoaHoc",
                table: "DangKyKhoaHocs");

            migrationBuilder.AddColumn<int>(
                name: "SoLuongHocVienHienTai",
                table: "KhoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DangKyKhoaHocs_MaKhoaHoc",
                table: "DangKyKhoaHocs",
                column: "MaKhoaHoc");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DangKyKhoaHocs_HocViens_MaHocVien",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropForeignKey(
                name: "FK_DangKyKhoaHocs_KhoaHocs_MaKhoaHoc",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropIndex(
                name: "IX_DangKyKhoaHocs_MaKhoaHoc",
                table: "DangKyKhoaHocs");

            migrationBuilder.DropColumn(
                name: "SoLuongHocVienHienTai",
                table: "KhoaHocs");

            migrationBuilder.AddColumn<int>(
                name: "HocVienMaHocVien",
                table: "DangKyKhoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "KhoaHocMaKhoaHoc",
                table: "DangKyKhoaHocs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DangKyKhoaHocs_HocVienMaHocVien",
                table: "DangKyKhoaHocs",
                column: "HocVienMaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyKhoaHocs_KhoaHocMaKhoaHoc",
                table: "DangKyKhoaHocs",
                column: "KhoaHocMaKhoaHoc");

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyKhoaHocs_HocViens_HocVienMaHocVien",
                table: "DangKyKhoaHocs",
                column: "HocVienMaHocVien",
                principalTable: "HocViens",
                principalColumn: "MaHocVien",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangKyKhoaHocs_KhoaHocs_KhoaHocMaKhoaHoc",
                table: "DangKyKhoaHocs",
                column: "KhoaHocMaKhoaHoc",
                principalTable: "KhoaHocs",
                principalColumn: "MaKhoaHoc",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
