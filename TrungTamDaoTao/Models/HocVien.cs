using System.ComponentModel.DataAnnotations;

namespace TrungTamDaoTao.Models
{
    public class HocVien
    {
        [Key]
        public int MaHocVien { get; set; }    // Khóa chính (ID học viên)
        public string HoTen { get; set; }     // Họ tên học viên
        public DateTime? NgaySinh { get; set; }  // Ngày sinh
        public string SoDienThoai { get; set; }  // Số điện thoại
        public string Email { get; set; }     // Email
        public string TaiKhoan { get; set; }  // Tài khoản
        public string MatKhau { get; set; }   // Mật khẩu

        // Điều hướng đến bảng DangKyKhoaHoc (mỗi học viên có thể đăng ký nhiều khóa học)
        public ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }
    }
}
