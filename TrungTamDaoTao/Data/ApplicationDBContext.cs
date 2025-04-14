using Microsoft.EntityFrameworkCore;
using TrungTamDaoTao.Models;

namespace TrungTamDaoTao.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> HocViens { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }
        public DbSet<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ giữa các bảng nếu cần thiết
            modelBuilder.Entity<DangKyKhoaHoc>()
                .HasKey(d => new { d.MaHocVien, d.MaKhoaHoc });  // Khóa chính của bảng DangKyKhoaHoc

            // Cấu hình quan hệ nhiều-nhiều (many-to-many)
            modelBuilder.Entity<DangKyKhoaHoc>()
                .HasOne(d => d.HocVien)
                .WithMany(h => h.DangKyKhoaHocs)  // HocVien có nhiều DangKyKhoaHocs
                .HasForeignKey(d => d.MaHocVien);

            modelBuilder.Entity<DangKyKhoaHoc>()
                .HasOne(d => d.KhoaHoc)
                .WithMany(k => k.DangKyKhoaHocs)  // KhoaHoc có nhiều DangKyKhoaHocs
                .HasForeignKey(d => d.MaKhoaHoc);
        }
    }
}
