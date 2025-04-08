using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamDaoTao.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HocViens",
                columns: table => new
                {
                    MaHocVien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaiKhoan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocViens", x => x.MaHocVien);
                });

            migrationBuilder.CreateTable(
                name: "KhoaHocs",
                columns: table => new
                {
                    MaKhoaHoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenKhoaHoc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiangVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiGianKhaiGiang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HocPhi = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SoLuongHocVien = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoaHocs", x => x.MaKhoaHoc);
                });

            migrationBuilder.CreateTable(
                name: "DangKyKhoaHocs",
                columns: table => new
                {
                    MaHocVien = table.Column<int>(type: "int", nullable: false),
                    MaKhoaHoc = table.Column<int>(type: "int", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HocVienMaHocVien = table.Column<int>(type: "int", nullable: false),
                    KhoaHocMaKhoaHoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangKyKhoaHocs", x => new { x.MaHocVien, x.MaKhoaHoc });
                    table.ForeignKey(
                        name: "FK_DangKyKhoaHocs_HocViens_HocVienMaHocVien",
                        column: x => x.HocVienMaHocVien,
                        principalTable: "HocViens",
                        principalColumn: "MaHocVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DangKyKhoaHocs_KhoaHocs_KhoaHocMaKhoaHoc",
                        column: x => x.KhoaHocMaKhoaHoc,
                        principalTable: "KhoaHocs",
                        principalColumn: "MaKhoaHoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangKyKhoaHocs_HocVienMaHocVien",
                table: "DangKyKhoaHocs",
                column: "HocVienMaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_DangKyKhoaHocs_KhoaHocMaKhoaHoc",
                table: "DangKyKhoaHocs",
                column: "KhoaHocMaKhoaHoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangKyKhoaHocs");

            migrationBuilder.DropTable(
                name: "HocViens");

            migrationBuilder.DropTable(
                name: "KhoaHocs");
        }
    }
}
