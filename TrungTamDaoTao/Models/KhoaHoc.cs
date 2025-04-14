
using System.ComponentModel.DataAnnotations;

namespace TrungTamDaoTao.Models
{
    public class KhoaHoc
    {
        [Key]
        [Display(Name = "Mã khóa học")]
        public int MaKhoaHoc { get; set; }    // Khóa chính (ID khóa học)

        [Display(Name = "Tên khoá học")]
        public string TenKhoaHoc { get; set; }  // Tên khóa học
        [Display(Name = "Tên giảng viên")]
        public string GiangVien { get; set; }  // Giảng viên
        [Display(Name = "Thời gian khai giảng")]
        public DateTime ThoiGianKhaiGiang { get; set; }  // Thời gian khai giảng
        [Display(Name = "Học phí")]
        public decimal HocPhi { get; set; }   // Học phí
        [Display(Name = "Số lượng học viên")]
        public int SoLuongHocVien { get; set; } // Số lượng học viên

        [Display(Name = "Học viên đã đăng ký")]
        public int SoLuongHocVienHienTai { get; set; } // Số lượng học viên hiện tại

        public ICollection<DangKyKhoaHoc> DangKyKhoaHocs { get; set; }
        public KhoaHoc()
        {
            DangKyKhoaHocs = new List<DangKyKhoaHoc>();
        }
    }
}
