namespace TrungTamDaoTao.Models
{
    public class DangKyKhoaHoc
    {
        public int MaHocVien { get; set; }     // Khóa học viên
        public int MaKhoaHoc { get; set; }     // Khóa học

        public DateTime NgayDangKy { get; set; }  // Ngày đăng ký

        // Điều hướng đến bảng KhoaHoc và HocVien
        public HocVien HocVien { get; set; }
        public KhoaHoc KhoaHoc { get; set; }
    }
}
