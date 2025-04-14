namespace TrungTamDaoTao.Models
{
    public class DangKyKhoaHoc
    {
        public int MaHocVien { get; set; }    // Khóa chính (ID học viên)
        public int MaKhoaHoc { get; set; }     // Khóa học

        public DateTime NgayDangKy { get; set; }  // Ngày đăng ký

        // Điều hướng đến bảng KhoaHoc và HocVien
        public User HocVien { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
    }
}
