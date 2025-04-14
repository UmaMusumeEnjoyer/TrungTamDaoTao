using Microsoft.EntityFrameworkCore;
using TrungTamDaoTao.Models;

namespace TrungTamDaoTao.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }
        public DbSet<KhoaHoc> KhoaHocs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình mối quan hệ giữa User và DangKyKhoaHoc (1-n)
            modelBuilder.Entity<DangKyKhoaHoc>()
                .HasOne(d => d.User)
                .WithMany(u => u.DangKyKhoaHocs)
                .HasForeignKey(d => d.MaHocVien)
                .OnDelete(DeleteBehavior.Restrict); // Có thể thay đổi DeleteBehavior theo yêu cầu

            // Cấu hình mối quan hệ giữa KhoaHoc và DangKyKhoaHoc (1-n)
            modelBuilder.Entity<DangKyKhoaHoc>()
                .HasOne(d => d.KhoaHoc)
                .WithMany(k => k.DangKyKhoaHocs)
                .HasForeignKey(d => d.MaKhoaHoc)
                .OnDelete(DeleteBehavior.Restrict); // Có thể thay đổi DeleteBehavior theo yêu cầu
        }
    }
}
