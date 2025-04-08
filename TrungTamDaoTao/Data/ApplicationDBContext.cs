using Microsoft.EntityFrameworkCore;
using TrungTamDaoTao.Models;

namespace TrungTamDaoTao.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<HocVien> HocViens { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ giữa các bảng nếu cần thiết
            modelBuilder.Entity<DangKyKhoaHoc>()
                .HasKey(d => new { d.MaHocVien, d.MaKhoaHoc });  // Khoá chính của bảng DangKyKhoaHoc

        }
    }
}
