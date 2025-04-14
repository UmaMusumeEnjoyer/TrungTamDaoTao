
using System.ComponentModel.DataAnnotations;

namespace TrungTamDaoTao.Models
{
    public class KhoaHoc
    {
        [Key]
        [Display(Name = "Mã khóa học")]
        public int MaKhoaHoc { get; set; }    

        [Display(Name = "Tên khoá học")]
        public string TenKhoaHoc { get; set; } 
        [Display(Name = "Tên giảng viên")]
        public string GiangVien { get; set; } 
        [Display(Name = "Thời gian khai giảng")]
        public DateTime ThoiGianKhaiGiang { get; set; }  
        [Display(Name = "Học phí")]
        public decimal HocPhi { get; set; }   
        [Display(Name = "Số lượng học viên")]
        public int SoLuongHocVien { get; set; } 

        [Display(Name = "Học viên đã đăng ký")]
        public int SoLuongHocVienHienTai { get; set; } 

        public ICollection<DangKyKhoaHoc>? DangKyKhoaHocs { get; set; }
    }
}
