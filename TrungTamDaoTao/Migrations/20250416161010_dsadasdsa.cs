using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamDaoTao.Migrations
{
    /// <inheritdoc />
    public partial class dsadasdsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isHocVien",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "isHocVien",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
