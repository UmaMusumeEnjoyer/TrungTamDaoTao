using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrungTamDaoTao.Migrations
{
    /// <inheritdoc />
    public partial class ewqewq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isHocVien",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isHocVien",
                table: "Users");
        }
    }
}
