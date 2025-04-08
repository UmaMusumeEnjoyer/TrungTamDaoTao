
using System.ComponentModel.DataAnnotations;

namespace TrungTamDaoTao.Models
{
    public class KhoaHoc
    {
        [Key]
        public int MaKhoaHoc { get; set; }    // Khóa chính (ID khóa học)
        public string TenKhoaHoc { get; set; }  // Tên khóa học
        public string GiangVien { get; set; }  // Giảng viên
        public DateTime ThoiGianKhaiGiang { get; set; }  // Thời gian khai giảng
        public decimal HocPhi { get; set; }   // Học phí
        public int SoLuongHocVien { get; set; } // Số lượng học viên

        public ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }
    }
}
